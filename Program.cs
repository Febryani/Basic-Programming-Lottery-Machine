using System;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			int pilih;
			string finalOpsi;

		welcome:
			Welcoming();
		backToMenu:
			Menu();
			pilih = int.Parse(Console.ReadLine());

			switch (pilih)
			{
				case 1:
					Beli();
					ToFinal();

					finalOpsi = Console.ReadLine();

					if (finalOpsi == "1")
					{
						Console.Clear();
						Mark();
						goto backToMenu;
					}
					else
					{
						Console.Clear();
						goto finish;
					}
					break;

				case 2:
					Undi();
					ToFinal();

					finalOpsi = Console.ReadLine();

					if (finalOpsi == "1")
					{
						Console.Clear();
                        Console.WriteLine("Ketik pilihan Anda");
						Mark();
						goto backToMenu;
					}
					else
					{
						Console.Clear();
						goto finish;
					}
					break;

				default:
					Console.Clear();
					Mark();
					Console.WriteLine("Sepertinya ada kesalahan pengetikan. ");
                    Console.WriteLine("Periksa kembali ya. Silahkan ketikan pilihan!");
					goto backToMenu;
					break;
			}

		finish:
			Mark();
            Console.WriteLine("Terima kasih atas kunjungannya!");
			System.Threading.Thread.Sleep(5000);
			Console.Clear();
			goto welcome;
		}


		static void Mark()
        {
			Console.WriteLine("==================================================================");
			Console.WriteLine(" ");
			Console.WriteLine("--------------------|       Betamart        |---------------------");
			Console.WriteLine("--------------------|    Lottery Machine    |---------------------");
			Console.WriteLine(" ");
			Console.WriteLine("==================================================================");
            Console.WriteLine(" ");
		}

		static void Welcoming()
		{
			string nama;

			Mark();
			Console.WriteLine(" ");
			Console.WriteLine("               ~   SELAMAT DATANG DI TOKO KAMI!  ~ ");
			Console.WriteLine(" ");
			System.Threading.Thread.Sleep(3000);
			Console.WriteLine("Halo... Siapa namamu?");
			nama = Console.ReadLine();
			Console.Clear();
			Mark();
			Console.WriteLine($"Halo {nama}!");
		}

		static void Menu()
		{
            Console.WriteLine(" ");
            Console.WriteLine("Silahkan pilih menu dibawah ini:");
			Console.WriteLine("1. Beli Lotre");
			Console.WriteLine("2. Undi Lotre");
		}

		static void Beli()
		{
			int quantity;
			int hargaLotre = 100000;
			int matchCounter = 0;
			string[] lotreCodes = new string[3];
			var random = new Random();

			Console.Clear();
			Mark();
			Console.WriteLine($"Harga tiket lotre: Rp {hargaLotre}");

			offer:
			Console.WriteLine("Mau beli? (Jawab dengan 'ya' atau 'tidak')");
			string jawab = Console.ReadLine();
			if (jawab == "ya")
			{
				Console.Clear();
				Mark();

			quanBeli:
				Console.WriteLine("Berapa banyak? Maksimal pembelian 3 tiket undian");
				quantity = int.Parse(Console.ReadLine());

				if (quantity <= 3)
				{
					Console.Clear();
					Mark();
					Console.WriteLine("Tiket lotre akan dicetak");
                    Console.WriteLine("Silahkan selesaikan pembayaran belanjaan anda di kasir");
					System.Threading.Thread.Sleep(1000);
					Console.WriteLine($"Total belanja: Rp. {Total(quantity, hargaLotre)}");
					Console.WriteLine(" ");
					System.Threading.Thread.Sleep(1000);
					Console.WriteLine("Berikut kode lotre anda:");

					//store lotre code as array value
					for (int i = 0; i < quantity; i ++)
                    {
						lotreCodes[i] = Convert.ToString(random.Next(10000, 99999));
						System.Threading.Thread.Sleep(1000);
						Console.WriteLine($"{(i + 1)}. {lotreCodes[i]}");
                    }

					Console.WriteLine(" ");
					System.Threading.Thread.Sleep(1000);
					Console.WriteLine("Mau undi tiket anda sekarang?");
					Console.WriteLine("1. ya");
					Console.WriteLine("2. tidak");
					int opsi = Convert.ToInt32(Console.ReadLine());
					Console.Clear();
					Mark();
					
					if (opsi == 1)
                    {
						for (int i=0; i < quantity; i++)
                        {
							Console.WriteLine((i+1)+ ". "+ lotreCodes[i]);
						}
                        Console.WriteLine("");
						Console.WriteLine("Tiket urutan nomor berapa yang ingin di undi?");
						opsi = Convert.ToInt32(Console.ReadLine());                                               
                        char[] codeUndi = lotreCodes[opsi-1].ToCharArray(0, 5);
						string codeReference = Convert.ToString(random.Next(10000, 99999));
						Console.Clear();
						Mark();
						Console.WriteLine($"Angka pada tiket lotre : {lotreCodes[opsi - 1]}");
						System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("");
						Console.WriteLine($"Angka beruntung        : {codeReference}");
                        Console.WriteLine("");
						System.Threading.Thread.Sleep(2000);


						//------------  match checking for choose the winner

						for (int i = 0; i < lotreCodes.Length; i++)
                        {
							if(codeReference.Contains((codeUndi[i]).ToString()))
                            {
								matchCounter++;
                            }
							continue;
                        }


						Console.WriteLine($"Banyak angka yang match adalah sejumlah {matchCounter} angka");
						System.Threading.Thread.Sleep(3000);

						if (matchCounter >= 3)
                        {
							Console.WriteLine("");
							Console.WriteLine("Selamat Anda Beruntung! Anda berhak mendapatkan hadiah berupa : ");
							Console.WriteLine("");
							System.Threading.Thread.Sleep(2000);
							Console.WriteLine("1. 2 tiket naik haji");
							Console.WriteLine("2. Uang senilai Rp. 50.000.000,-");
							Console.WriteLine("3. Emas seberat 10 gram");
							Console.WriteLine("4. Voucher belanja Betamart diskon 25%");
							System.Threading.Thread.Sleep(2000);
							Console.WriteLine("");
							Console.WriteLine("Silahkan hubungi petugas Betamart untuk melakukan pengambilan hadiah!");
							System.Threading.Thread.Sleep(2000);
						}
						else if(matchCounter >=1 && matchCounter < 3)
                        {
							Console.WriteLine("");
							Console.WriteLine("Selamat Anda Beruntung! Anda berhak mendapatkan hadiah berupa: ");
							Console.WriteLine("");
							System.Threading.Thread.Sleep(2000);
							Console.WriteLine("Voucher belanja Betamart diskon 25%");
							System.Threading.Thread.Sleep(2000);
							Console.WriteLine("");
							Console.WriteLine("Silahkan hubungi petugas Betamart untuk pengambilan hadiah!");
							System.Threading.Thread.Sleep(2000);
						}
						else
						{
							System.Threading.Thread.Sleep(3000);
							Console.WriteLine("");
							Console.WriteLine("Yah... Sayangnya Anda belum beruntung. Coba lagi lain kali.");
							System.Threading.Thread.Sleep(2000);
						}
					}
                
				}
				else
                {
					Console.Clear();
					Mark();
					Console.WriteLine("Pembelian melebihi batas.");
					goto quanBeli;
                }

			}
			else if (jawab == "tidak")
			{
				
				Console.Clear();
				Mark();
				Console.WriteLine("Baik terima kasih");
			}
			else
			{
				Console.Clear();
				Mark();
				Console.WriteLine("Ada kesalahan input. Periksa kembali!");
				goto offer;
			}
		}


		static int Total(int x, int y)
		{
			return x * y;
		}

		static void Undi()
		{
			char[] input = new char[5]; //membatasi input number sebanyak 5 angka
			int count = input.Length;
			int numberInt;
			int matchCounter = 0;
			var random = new Random();
			string codeReference = Convert.ToString(random.Next(10000, 99999));
			string errorInput;
			string removed = "Ada kesalahan input. Pastikan yang anda masukan adalah single number!";

			Console.Clear();

			error_reinput:
			Mark();
			Console.WriteLine("Silahkan masukan 5 single number pada baris berbeda ");
            Console.WriteLine("sesuai nomor yang tertera pada tiket lotre Anda : ");
			for (int i = 0; i < count; i++)
			{
                try
                {
					input[i] = char.Parse(Console.ReadLine());
                }
				catch
                {
					Console.WriteLine(removed);
					System.Threading.Thread.Sleep(2000);
					errorInput = Convert.ToString(input[i]);
					errorInput=errorInput.Replace("[errorInput]", string.Empty);
					Console.Clear();
					goto error_reinput;
				}
				
			}

			if (count == 5)
			{
				string newInput = string.Join("", input);

				try
                {
					numberInt = int.Parse(newInput);
                }
				catch
                {
					Console.WriteLine("Ada kesalahan input. Pastikan yang anda masukan adalah berupa angka!");
					System.Threading.Thread.Sleep(2000);
					Console.Clear();
					goto error_reinput;
				}
				

				if (int.TryParse(newInput, out numberInt))
				{
                    Console.WriteLine("");
                    Console.WriteLine($"Angka pada tiket lotre Anda : {newInput}");
                    Console.WriteLine("");
					System.Threading.Thread.Sleep(2000);
					Console.WriteLine($"Angka beruntung             : {codeReference}");
                    Console.WriteLine("");
					char[] newInputs = newInput.ToCharArray(0, 5);
					System.Threading.Thread.Sleep(3000);

					for (int i = 0; i < newInputs.Length; i++)
					{
						if (codeReference.Contains((newInputs[i]).ToString()))
						{
							matchCounter++;
						}
						continue;
					}


					Console.WriteLine($"Banyak angka yang match adalah sejumlah {matchCounter} angka");
					System.Threading.Thread.Sleep(3000);

					if (matchCounter >= 3)
					{
						Console.WriteLine("");
						Console.WriteLine("Selamat Anda Beruntung! Anda berhak mendapatkan hadiah berupa : ");
						Console.WriteLine("");
						System.Threading.Thread.Sleep(2000);
						Console.WriteLine("1. 2 tiket naik haji");
						Console.WriteLine("2. Uang senilai Rp. 50.000.000,-");
						Console.WriteLine("3. Emas seberat 10 gram");
						Console.WriteLine("4. Voucher belanja Betamart diskon 25%");
						System.Threading.Thread.Sleep(2000);
						Console.WriteLine("");
						Console.WriteLine("Silahkan hubungi petugas Betamart untuk melakukan pengambilan hadiah!");
						System.Threading.Thread.Sleep(2000);
					}
					else if (matchCounter >= 1 && matchCounter < 3)
					{
						Console.WriteLine("");
						Console.WriteLine("Selamat Anda Beruntung! Anda berhak mendapatkan hadiah berupa: ");
						Console.WriteLine("");
						System.Threading.Thread.Sleep(2000);
						Console.WriteLine("Voucher belanja Betamart diskon 25%");
						System.Threading.Thread.Sleep(2000);
						Console.WriteLine("");
						Console.WriteLine("Silahkan hubungi petugas Betamart untuk pengambilan hadiah!");
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						System.Threading.Thread.Sleep(3000);
						Console.WriteLine("");
						Console.WriteLine("Yah... Sayangnya Anda belum beruntung. Coba lagi lain kali.");
						System.Threading.Thread.Sleep(2000);
					}

				}
				else
				{
					Console.WriteLine("Ada kesalahan input. Pastikan yang Anda inputkan adalah single number!");
					goto error_reinput;
				}
			}
			else
			{
				Console.WriteLine("Perika kembali! Anda harus menginputkan 5 single number.");
			}
		}

		static void ToFinal()
		{
			System.Threading.Thread.Sleep(3000);
			Console.Clear();
			Mark();
			Console.WriteLine(" ");
			Console.WriteLine("Selanjutnya ...");
			Console.WriteLine("1. Kembali ke menu awal");
			Console.WriteLine("2. Keluar");
		}

	}
}
