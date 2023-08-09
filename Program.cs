using System;

namespace MyApp
{
    // tạo lớp thời gian
    // lớp thời gian này là loại 24h
    public class ThoiGian
    {
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public int gio { get; set; }
        public int phut { get; set; }
        public int giay { get; set; }

        // hàm khởi tạo có tham số
        public ThoiGian(int data_ngay = 1,
                        int data_thang = 1,
                        int data_nam = 1,
                        int data_gio = 0,
                        int data_phut = 0,
                        int data_giay = 0)
        {
            ngay = data_ngay;
            thang = data_thang;
            nam = data_nam;
            gio = data_gio;
            phut = data_phut;
            giay = data_giay;
        }

        // nạp chồng hàm khởi tạo có tham số
        // ví dụ bạn nhập "01/01/2023"
        // thì nó sẽ tự động nhận dạng cho bạn
        public ThoiGian(string str)
        {
            if (str.Contains("/") == true)
            {
                // nếu chuỗi string có định dạng "dd/MM/yyyy"
                // chuyển string sang mảng
                string[] arr = str.Split("/");

                ngay = Convert.ToInt32(arr[0]);
                thang = Convert.ToInt32(arr[1]);
                nam = Convert.ToInt32(arr[2]);
            }
            else if (str.Contains("-") == true)
            {
                // nếu chuỗi string có định dạng "yyyy-MM-dd"
                // chuyển string sang mảng
                string[] arr = str.Split("-");

                nam = Convert.ToInt32(arr[0]);
                thang = Convert.ToInt32(arr[1]);
                ngay = Convert.ToInt32(arr[2]);
            }

            // giờ, phút, giây thì tự động bằng 0
            gio = 0;
            phut = 0;
            giay = 0;
        }

        // nạp chồng phương thức ToString
        public string ToString(string dinh_dang = "")
        {
            string str_ngay = ngay.ToString();
            string str_thang = thang.ToString();
            string str_nam = nam.ToString();
            string str_gio = gio.ToString();
            string str_phut = phut.ToString();
            string str_giay = giay.ToString();

            if (ngay < 10)
            {
                str_ngay = "0" + str_ngay;
            }

            if (thang < 10)
            {
                str_thang = "0" + str_thang;
            }

            if (str_nam.Length <= 1)
            {
                str_nam = "000" + str_nam;
            }
            else if (str_nam.Length <= 2)
            {
                str_nam = "00" + str_nam;
            }
            else if (str_nam.Length <= 3)
            {
                str_nam = "0" + str_nam;
            }

            if (str_gio.Length <= 1)
            {
                str_gio = "0" + str_gio;
            }

            if (str_phut.Length <= 1)
            {
                str_phut = "0" + str_phut;
            }

            if (str_giay.Length <= 1)
            {
                str_giay = "0" + str_giay;
            }

            // tạo biến kết quả
            string ketQua = $"{str_ngay}/{str_thang}/{str_nam} {str_gio}:{str_phut}:{str_giay}";

            if (dinh_dang.ToLower() == "dd/mm/yyyy")
            {
                ketQua = $"{str_ngay}/{str_thang}/{str_nam}"; ;
            }
            else if (dinh_dang.ToLower() == "dd/mm/yyyy hh:mm")
            {
                ketQua = $"{str_ngay}/{str_thang}/{str_nam} {str_gio}:{str_phut}";
            }
            else if (dinh_dang.ToLower() == "dd/mm/yyyy hh:mm:ss")
            {
                ketQua = $"{str_ngay}/{str_thang}/{str_nam} {str_gio}:{str_phut}:{str_giay}";
            }
            else if (dinh_dang.ToLower() == "yyyy/mm/dd")
            {
                ketQua = $"{str_nam}/{str_thang}/{str_ngay}";
            }
            else if (dinh_dang.ToLower() == "hh:mm:ss")
            {
                ketQua = $"{str_gio}:{str_phut}:{str_giay}";
            }
            else if (dinh_dang.ToLower() == "hh:mm")
            {
                ketQua = $"{str_gio}:{str_phut}";
            }
            else if (dinh_dang.ToLower() == "mm:ss")
            {
                ketQua = $"{str_phut}:{str_giay}";
            }

            return ketQua;
        }

        // hàm trả về ngày mai
        public ThoiGian ngay_mai()
        {
            ThoiGian ketQua = new ThoiGian();

            // tạo mảng
            // chứa tổng số ngày trong 1 tháng
            // của từng tháng
            // từ tháng 1 đến tháng 12
            int[] arr = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

            // kiểm tra năm nhuận
            if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))
            {
                arr[1] = 29;
            }

            if (ngay == 31 && thang == 12)
            {
                ketQua.ngay = 1;
                ketQua.thang = 1;
                ketQua.nam = nam + 1;
            }
            else if (ngay == arr[thang - 1] && thang != 12)
            {
                ketQua.ngay = 1;
                ketQua.thang = thang + 1;
                ketQua.nam = nam;
            }
            else if (ngay != arr[thang - 1])
            {
                ketQua.ngay = ngay + 1;
                ketQua.thang = thang;
                ketQua.nam = nam;
            }

            return ketQua;
        }

        // hàm trả về hôm qua
        public ThoiGian hom_qua()
        {
            ThoiGian ketQua = new ThoiGian();

            // tạo mảng
            // chứa tổng số ngày trong 1 tháng
            // của từng tháng
            // từ tháng 1 đến tháng 12
            int[] arr = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // kiểm tra năm nhuận
            if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))
            {
                arr[1] = 29;
            }

            if (ngay == 1 && thang == 1)
            {
                ketQua.ngay = 31;
                ketQua.thang = 12;
                ketQua.nam = nam - 1;
            }
            else if (ngay == 1 && thang != 1)
            {
                ketQua.ngay = arr[thang - 2];
                ketQua.thang = thang - 1;
                ketQua.nam = nam;
            }
            else if (ngay != 1)
            {
                ketQua.ngay = ngay - 1;
                ketQua.thang = thang;
                ketQua.nam = nam;
            }

            return ketQua;
        }

        // hàm trả về giây tiếp theo
        public ThoiGian giay_TiepTheo()
        {
            ThoiGian ketQua = this;

            if (gio == 23 && phut == 59 && giay == 59)
            {
                // gọi thêm cái hàm in ra ngày mai
                ketQua = this.ngay_mai();

                ketQua.gio = 0;
                ketQua.phut = 0;
                ketQua.giay = 0;
            }
            else if (gio != 23 && phut == 59 && giay == 59)
            {
                ketQua.gio = gio + 1;
                ketQua.phut = 0;
                ketQua.giay = 0;
            }
            else if (phut != 59 && giay == 59)
            {
                ketQua.gio = gio;
                ketQua.phut = phut + 1;
                ketQua.giay = 0;
            }
            else if (giay != 59)
            {
                ketQua.gio = gio;
                ketQua.phut = phut;
                ketQua.giay = giay + 1;
            }

            return ketQua;
        }

        // hàm trả về giây trước
        public ThoiGian giay_Truoc()
        {
            ThoiGian ketQua = this;

            if (gio == 0 && phut == 0 && giay == 0)
            {
                // gọi thêm cái hàm in ra hôm qua
                ketQua = this.hom_qua();

                ketQua.gio = 23;
                ketQua.phut = 59;
                ketQua.giay = 59;
            }
            else if (gio != 0 && phut == 0 && giay == 0)
            {
                ketQua.gio = gio - 1;
                ketQua.phut = 59;
                ketQua.giay = 59;
            }
            else if (phut != 0 && giay == 0)
            {
                ketQua.gio = gio;
                ketQua.phut = phut - 1;
                ketQua.giay = 59;
            }
            else if (giay != 0)
            {
                ketQua.gio = gio;
                ketQua.phut = phut;
                ketQua.giay = giay - 1;
            }

            return ketQua;
        }

        // nạp chồng toán tử +
        // dùng để cộng giây
        // cái tham số n là giây nhé
        public static ThoiGian operator +(ThoiGian dt, long n)
        {
            ThoiGian ketQua = new ThoiGian();

            ketQua.ngay = dt.ngay;
            ketQua.thang = dt.thang;
            ketQua.nam = dt.nam;
            ketQua.gio = dt.gio;
            ketQua.phut = dt.phut;
            ketQua.giay = dt.giay;

            if (n == 0)
            {
                return ketQua;
            }
            
            for (long i = 1; i <= n; i++)
            {
                ketQua = ketQua.giay_TiepTheo();
            }

            return ketQua;
        }

        // nạp chồng toán tử -
        // dùng để trừ giây
        // cái tham số n là giây nhé
        public static ThoiGian operator -(ThoiGian dt, long n)
        {
            ThoiGian ketQua = new ThoiGian();

            ketQua.ngay = dt.ngay;
            ketQua.thang = dt.thang;
            ketQua.nam = dt.nam;
            ketQua.gio = dt.gio;
            ketQua.phut = dt.phut;
            ketQua.giay = dt.giay;

            if (n == 0)
            {
                return ketQua;
            }

            for (long i = 1; i <= n; i++)
            {
                ketQua = ketQua.giay_Truoc();
            }

            return ketQua;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng
            ThoiGian dt1 = new ThoiGian();
            ThoiGian dt2 = new ThoiGian(9, 12, 2023, 22, 19);
            ThoiGian dt3 = new ThoiGian(31, 1, 2004, 19, 0, 59);


            // hiển thị ra màn hình
            Console.WriteLine("-------------------- HIEN THI DU LIEU --------------------");
            Console.WriteLine(dt1.ToString());
            Console.WriteLine(dt2.ToString("dd/MM/yyyy hh:mm"));
            Console.WriteLine(dt3.ToString("dd/MM/yyyy"));


            // in ra giây tiếp theo
            Console.WriteLine("\n\n------------------ IN RA GIAY TIEP THEO ------------------");
            ThoiGian dt4 = new ThoiGian(31, 12, 2000, 23, 59, 59);
            Console.WriteLine($"Ban dau: {dt4.ToString()}\t\tLuc sau: {dt4.giay_TiepTheo().ToString()}\n");

            ThoiGian dt5 = new ThoiGian(1, 1, 1, 18, 59, 59);
            Console.WriteLine($"Ban dau: {dt5.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt5.giay_TiepTheo().ToString("hh:mm:ss")}");

            ThoiGian dt6 = new ThoiGian(1, 1, 1, 9, 50, 59);
            Console.WriteLine($"Ban dau: {dt6.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt6.giay_TiepTheo().ToString("hh:mm:ss")}");

            ThoiGian dt7 = new ThoiGian(1, 1, 1, 6, 0, 0);
            Console.WriteLine($"Ban dau: {dt7.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt7.giay_TiepTheo().ToString("hh:mm:ss")}");


            // in ra giây trước
            Console.WriteLine("\n\n-------------------- IN RA GIAY TRUOC --------------------");
            ThoiGian dt14 = new ThoiGian(19, 5, 2007, 0, 0, 0);
            Console.WriteLine($"Ban dau: {dt14.ToString()}\t\tLuc sau: {dt14.giay_Truoc().ToString()}\n");

            ThoiGian dt15 = new ThoiGian(1, 1, 1, 18, 0, 0);
            Console.WriteLine($"Ban dau: {dt15.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt15.giay_Truoc().ToString("hh:mm:ss")}");

            ThoiGian dt16 = new ThoiGian(1, 1, 1, 23, 10, 40);
            Console.WriteLine($"Ban dau: {dt16.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt16.giay_Truoc().ToString("hh:mm:ss")}");

            ThoiGian dt17 = new ThoiGian(1, 1, 1, 7, 20, 0);
            Console.WriteLine($"Ban dau: {dt17.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt17.giay_Truoc().ToString("hh:mm:ss")}");


            // in ra ngày mai
            Console.WriteLine("\n\n--------------------- IN RA NGAY MAI ---------------------");
            ThoiGian dt8 = new ThoiGian(31, 12, 2023);
            Console.WriteLine($"Ban dau: {dt8.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt8.ngay_mai().ToString("dd/MM/yyyy")}");

            ThoiGian dt9 = new ThoiGian(28, 2, 1999);
            Console.WriteLine($"Ban dau: {dt9.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt9.ngay_mai().ToString("dd/MM/yyyy")}");

            ThoiGian dt10 = new ThoiGian(28, 2, 2000);
            Console.WriteLine($"Ban dau: {dt10.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt10.ngay_mai().ToString("dd/MM/yyyy")}");

            ThoiGian dt11 = new ThoiGian(3, 3, 2003);
            Console.WriteLine($"Ban dau: {dt11.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt11.ngay_mai().ToString("dd/MM/yyyy")}");

            // in ra hôm qua
            Console.WriteLine("\n\n---------------------- IN RA HOM QUA ----------------------");
            ThoiGian dt18 = new ThoiGian(1, 1, 2023);
            Console.WriteLine($"Ban dau: {dt18.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt18.hom_qua().ToString("dd/MM/yyyy")}");

            ThoiGian dt19 = new ThoiGian(1, 3, 2020);
            Console.WriteLine($"Ban dau: {dt19.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt19.hom_qua().ToString("dd/MM/yyyy")}");

            ThoiGian dt20 = new ThoiGian(1, 3, 2019);
            Console.WriteLine($"Ban dau: {dt20.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt20.hom_qua().ToString("dd/MM/yyyy")}");

            ThoiGian dt21 = new ThoiGian(15, 6, 2023);
            Console.WriteLine($"Ban dau: {dt21.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt21.hom_qua().ToString("dd/MM/yyyy")}");


            // nạp chồng toán tử +
            Console.WriteLine("\n\n------------------- NAP CHONG TOAN TU + -------------------");
            ThoiGian dt12 = new ThoiGian(1, 1, 2000, 0, 0, 1);
            ThoiGian tong1 = dt12 + 86400;
            Console.WriteLine($"{dt12.ToString("dd/MM/yyyy hh:mm:ss")}    +    {"86400 (giay)", -15} =    {tong1.ToString("dd/MM/yyyy hh:mm:ss")}");

            ThoiGian dt13 = new ThoiGian(22, 9, 2021, 4, 8, 55);
            ThoiGian tong2 = dt13 + 5;
            Console.WriteLine($"{dt13.ToString("dd/MM/yyyy hh:mm:ss")}    +    {"5 (giay)", -15} =    {tong2.ToString("dd/MM/yyyy hh:mm:ss")}");


            // nạp chồng toán tử -
            Console.WriteLine("\n\n------------------- NAP CHONG TOAN TU - -------------------");
            ThoiGian dt22 = new ThoiGian(15, 2, 2000, 10, 9, 48);
            ThoiGian hieu1 = dt22 - 86400;
            Console.WriteLine($"{dt22.ToString("dd/MM/yyyy hh:mm:ss")}    -    {"86400 (giay)",-15} =    {hieu1.ToString("dd/MM/yyyy hh:mm:ss")}");

            ThoiGian dt23 = new ThoiGian(5, 12, 2021, 9, 20, 48);
            ThoiGian hieu2 = dt23 - 1;
            Console.WriteLine($"{dt23.ToString("dd/MM/yyyy hh:mm:ss")}    -    {"1 (giay)",-15} =    {hieu2.ToString("dd/MM/yyyy hh:mm:ss")}");


            // định dạng thời gian
            // ngay từ lúc khởi tạo
            ThoiGian thoiGian = new ThoiGian("2007-05-19");
            Console.WriteLine($"\n\nNeu ban nhap:\t\"2007-05-19\"\nKet qua:\t{thoiGian.ToString()}");
        }
    }
}