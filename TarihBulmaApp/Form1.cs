using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarihBulmaApp
{
    public partial class Form1 : Form
    {
        //Gün bazlı filtreleme yapmak istenirse tıklanan günlerin değerlerini tutmak için tüm methodlardan erişilebilir bir public string listesi oluşturduk
        public List<string> clickedBtnList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        //Günlük yada haftalık seçeneklerinde istenilen aralık her değiştiğinde işlemleri tekrar yapmak için başlangıç sorgusunu barındıran methodu çağırdım
        private void cbBox02_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedFilter();
        }
        //Her tarih değiştiğinde listedeki değerleri otomatik güncellemek için bu Event'i ekledim ve günlük mü haftalık mı sorgusunun methodunu çağırdım
        private void mCalendar01_DateChanged(object sender, DateRangeEventArgs e)
        {
            MonthCalendar date1 = mCalendar01;
            MonthCalendar date2 = mCalendar02;
            if(date1.SelectionRange.Start > date2.SelectionRange.Start)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if(date2.SelectionRange.Start < date1.SelectionRange.Start)
            {
                MessageBox.Show("Bitiş tarihi başlangıç tarihinden küçük olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GetSelectedFilter();
            }
        }
        #region Günlük ve Haftalık Filtreleme İşlemleri İçin ComboBox'ların içini burada Dolduruyoruz
        private void cbBox01_SelectedIndexChanged(object sender, EventArgs e)
        {
            //İşlem her değiştiğinde listeyi boşaltarak yeni sorguya göre düzenliyoruz
            Lbox01.Items.Clear();
            cbBox02.SelectedItem = null;
            //Seçilen değeri alıyoruz. Günlük mü haftalık mı filtrelemek istiyoruz onun değerini buluyoruz
            int selectOption = cbBox01.SelectedIndex;
            //Eğer değer -1 gelirse herhangi bir işlem seçilmemiştir. Bu yüzden herhangi bir işlem yapmıyoruz.
            if (selectOption == -1)
            {
                daysPanel.Visible = false;
            }
            //Eğer değer 0 gelirse Günlük filtreleme seçilmiştir. Bu yüzden güne göre listeleme yapabilmek için diğer combobox ın içerisini 1-31 gün aralığı ile dolduruyoruz
            else if (selectOption == 0)
            {
                //Haftalık işlemler yapılmayacağı için gün bazlı filtreleme alanını görünmez halde tutuyoruz
                daysPanel.Visible = false;
                cbBox02.Items.Clear();
                for (int i = 1; i < 32; i++)
                {
                    cbBox02.Items.Add($"{i} Günlük");
                }
            }
            //Eğer değer 1 ise Haftalık filtreleme işlemi seçilmiştir. Bu yüzden haftaya göre listeleme yapabilmek için 1-8 hafta aralığındaki değerler ile combobox'ı dolduruyoruz. Ayrıca gün bazlı filtreleme işlemi de aktif olacağı için günlerin bulunduğu butonların panelini de görünür hale getiriyoruz
            else if (selectOption == 1)
            {
                daysPanel.Visible = true;
                cbBox02.Items.Clear();
                for (int i = 1; i < 9; i++)
                {
                    cbBox02.Items.Add($"{i} Haftalık");
                }
            }
        }
        #endregion

        #region Günlük Hesaplama İşlemleri Burada
        private void GetDailyList()
        {
            MonthCalendar date1 = mCalendar01;
            MonthCalendar date2 = mCalendar02;
            //Seçilen 2 tarih arasındaki gün sayısını buluyoruz
            var totalDay = (date2.SelectionStart - date1.SelectionStart).TotalDays;
            int selectedOption = 0;
            //menüden seçilen günlük yada haftalık seçeğeninin indexi 0 dan başladığı için gerçek değerini almak için +1 ekleyerek değişkene atıyoruz
            int selectedDay = cbBox02.SelectedIndex + 1;
            //Eğer menüden hiçbir seçenek seçilmediyse 1 er artan seçeneği varsayılan değer yapıyoruz
            if (cbBox02.SelectedIndex == -1)
            {
                selectedOption = 0;
            }
            //Eğer menüden işlem seçildiyse indexini alıp +1 ekleyerek gerçek değerini değişkene atıyoruz
            else
            {
                selectedOption = cbBox02.SelectedIndex + 1;
            }
            //Yazdırma işlemlerine başlamadan önce her defasında ListBox'ın içerisini boşaltıyoruz
            Lbox01.Items.Clear();
            //Eğer herhangi bir gün sayısı seçilmişse başlangıç değerine +1 gün ekleyerek başlayacağı için ilk gün değerini listeye yazmayacak. Bunun için ilk günü burada yazıyoruz
            if (selectedDay != 0)
            {
                Lbox01.Items.Add(date1.SelectionRange.Start);
            }
            //Girilen 2 tarih arasındaki toplam gün sayısı kadar döngüye başlıyoruz
            for (int i = 0; i <= totalDay; i++)
            {
                //Menüden seçilen günlük değerini seçilen ilk günün üzerine ekleyerek yeni gün oluşturuyoruz
                var writeDate = date1.SelectionRange.Start.AddDays(selectedOption);
                //Oluşturulan gün seçilen son tarih değerinden küçük ise listeye ekleme işlemi yapıyoruz
                if (writeDate <= date2.SelectionStart)
                {
                    Lbox01.Items.Add(writeDate);
                }
                //Burada kullanıcının günlük değeri girip girmediğini kontrol ediyoruz. Eğer true dönerse herhangi bir seçenek seçmediği için tekrar varsayılan değer olarak 1 er arttırma işlemini yapıyoruz
                if (selectedDay - 1 == -1)
                {
                    selectedOption += 1;
                }
                //Eğer kullanıcı günlük değer girdiyse belirlenen değeri değişkene atayıp gönderiyoruz
                else
                {
                    selectedOption += selectedDay;
                }
            }
        }
        #endregion

        #region Haftalık Hesaplama İşlemleri Burada
        private void GetWeeklyList()
        {
            MonthCalendar date1 = mCalendar01;
            MonthCalendar date2 = mCalendar02;
            //Seçilen 2 tarih arasındaki gün sayısını buluyoruz
            var totalDay = (date2.SelectionStart - date1.SelectionStart).TotalDays;
            int selectedOption = 0;
            //menüden seçilen günlük yada haftalık seçeğeninin indexi 0 dan başladığı için gerçek değerini almak için +1 ekleyerek değişkene atıyoruz
            int selectedWeek = cbBox02.SelectedIndex + 1;
            //Eğer menüden hiçbir seçenek seçilmediyse 1 er artan seçeneği varsayılan değer yapıyoruz
            if (cbBox02.SelectedIndex == -1)
            {
                selectedOption = 1;
            }
            //Eğer menüden işlem seçildiyse indexini alıp +1 ekleyerek gerçek değerini değişkene atıyoruz
            else
            {
                selectedOption = cbBox02.SelectedIndex + 1;
            }
            //Yazdırma işlemlerine başlamadan önce her defasında ListBox'ın içerisini boşaltıyoruz
            Lbox01.Items.Clear();
            //Eğer günlük işlemlerden haftalık işlemlere geçiş yaptıysak ve herhangi bir haftalık değer belirlenmediyse seçilen ilk gün değerini de listeye ekleyerek varsayılan değer aralığını 1 hafta olarak belirliyoruz
            if (cbBox02.SelectedIndex == -1 && clickedBtnList.Count == 0)
            {
                Lbox01.Items.Add(date1.SelectionRange.Start);
            }
            //Eğer herhangi bir işlem seçildiyse seçilen başlangıç değerinin üzerine 1 gün ekleyerek yazmaya başlayacak. Bu yüzden başlangıç gün değerini de ListBox'a yazdırmak için ayrıca haftalık seçeneğinde gün belirlenmemiş ise başlangıç değerini yazıyoruz.
            if (selectedWeek != 0 && clickedBtnList.Count == 0)
            {
                Lbox01.Items.Add(date1.SelectionRange.Start);
            }
            //Seçilen 2 tarih arasındaki gün sayısı kadar döngüde dönüyoruz
            for (int i = 0; i <= totalDay; i++)
            {
                //Eğer filtrelemek için herhangi bir gün seçilmediyse menüden seçilen kaç haftalık değerine göre listeye yazıyoruz
                if (clickedBtnList.Count <= 0)
                {
                    //Menüden seçilen haftalık değerin gün sayısını ilk girilen değerin üzerine ekliyoruz
                    var writeDate = date1.SelectionRange.Start.AddDays(selectedOption * 7);
                    //Belirlenen haftalık değerine göre yukarıda eklediğimiz yeni değerin bitiş tarihinden büyük mü küçük mü olduğunu sorguluyoruz. Eğer küçükse listeye yazıyoruz
                    if (writeDate <= date2.SelectionStart)
                    {
                        Lbox01.Items.Add(writeDate);
                    }
                    //Burada kullanıcının haftalık değeri girip girmediğini kontrol ediyoruz. Eğer true dönerse herhangi bir seçenek seçmediği için tekrar varsayılan değer olarak 1 er arttırma işlemini yapıyoruz
                    if (selectedWeek - 1 == -1)
                    {
                        selectedOption += 1;
                    }
                    //Eğer kullanıcı haftalık değer girdiyse belirlenen değeri değişkene atayıp gönderiyoruz
                    else
                    {
                        selectedOption += selectedWeek;
                    }
                }
                //Filtrelemek için herhangi bir gün seçildiyse işlemlere buradan başlıyoruz
                else if (clickedBtnList.Count > 0)
                {
                    //Gün bazlı filtreleme yapacağı için belirlenen tarihler arasında istenilen günleri listeye eklemek için her günü tek tek kontrol edebilmek için teker teker gün ekliyoruz 
                    var writeDate = date1.SelectionRange.Start.AddDays(selectedOption - 1);
                    //Yeni oluşturulan gün bitiş değerinden küçük yada eşitse işlem yapıyoruz
                    if (writeDate <= date2.SelectionStart)
                    {
                        //Burada filtrelemek için tıklanan butonların kaydını tuttuğumuz listenin içerisindeki eleman sayısı kadar dönüyoruz
                        for (int j = 0; j < clickedBtnList.Count; j++)
                        {
                            //Listenin her bir elemanı ile yeni oluşturulan günü karşılaştırıp filtrelemek istenilen gün ise listeye ekliyoruz
                            if (clickedBtnList[j] == writeDate.ToString("dddd"))
                            {
                                Lbox01.Items.Add(writeDate);
                            }
                        }
                    }
                    //Burada kullanıcının haftalık değeri girip girmediğini kontrol ediyoruz. Eğer true dönerse herhangi bir seçenek seçmediği için tekrar varsayılan değer olarak 1 er arttırma işlemini yapıyoruz
                    if (selectedWeek - 1 == -1)
                    {
                        selectedOption += 1;
                    }
                    //Eğer kullanıcı haftalık değer girdiyse belirlenen değeri değişkene atayıp gönderiyoruz
                    else
                    {
                        selectedOption += selectedWeek;
                    }
                }
            }
        }
        #endregion

        #region Haftalık mı Günlük mü Hesaplanmak İsteniyor Kontrolü Burada
        private void GetSelectedFilter()
        {
            //İlk combobox'ımızın seçilen indexini buluyoruz. Eğer günlük ise gerekli methodu haftalık ise gerekli methodu çağırıyoruz. Herhangi bir kriter seçilmediyse, herhangi bir işlem yaptırmıyoruz
            if (cbBox01.SelectedIndex + 1 == 1)
            {
                GetDailyList();
            }
            if (cbBox01.SelectedIndex + 1 == 2)
            {
                GetWeeklyList();
            }
        }
        #endregion

        #region Haftalık Listeleme için Gün Bazlı Filtrelemede Tıklanan Buton Bilgilerini Buradan Alıyoruz
        private void Btn_OnClick(object sender, EventArgs e)
        {
            //Öncelikle tıklanan butonun bilgisini buluyoruz
            Button btn = (Button)sender;

            //Tıklanan buton aktif ise tekrar tıklandığı için pasife çekiyoruz. Arkaplan rengini kaldırıyoruz
            if (btn.BackColor == Color.Red)
            {
                btn.BackColor = DefaultBackColor;
            }
            //Eğer aktif değilse butonu aktif yaparak arkaplan rengi ekliyoruz
            else
            {
                btn.BackColor = Color.Red;
            }
            //Eğer buton aktif edildiyse aktif olan butonların bilgisini tuttuğumuz listemize ekliyoruz
            if (btn.BackColor == Color.Red)
            {
                clickedBtnList.Add(btn.Text);
            }
            //Tuttuğumuz listenin içerisindeki elemanları tek tek sorgulayabilmek için listenin boyutu kadar döngüye sokuyoruz. Eğer buton listede varsa ve aktiften pasife çekildiyse butonun bilgilerini listeden kaldırıyoruz
            for (int i = 0; i < clickedBtnList.Count; i++)
            {
                if (clickedBtnList[i] == btn.Text && btn.BackColor != Color.Red)
                {
                    clickedBtnList.RemoveAt(i);
                }
            }
            //Gün bazlı filtreleme yapılmak istendiği için haftalık işlemlerin yapıldığı methodumuzu çağırıyoruz
            GetWeeklyList();
        }
        #endregion
    }
}
