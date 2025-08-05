namespace Patikaflix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Series> tvSeriesList = new List<Series>
            {
                new Series { Name = "Avrupa Yakası", ProductionYear = 2004, ReleaseYear = 2004, Genre = "Komedi", Director = "Yüksel Aksu", Platform = "Kanal D" },
                new Series { Name = "Yalan Dünya", ProductionYear = 2012, ReleaseYear = 2012, Genre = "Komedi", Director = "Gülseren Buda Başkaya", Platform = "Fox TV" },
                new Series { Name = "Jet Sosyete", ProductionYear = 2018, ReleaseYear = 2018, Genre = "Komedi", Director = "Gülseren Buda Başkaya", Platform = "TV8" },
                new Series { Name = "Dadı", ProductionYear = 2006, ReleaseYear = 2006, Genre = "Komedi", Director = "Yusuf Pirhasan", Platform = "Kanal D" },
                new Series { Name = "Belalı Baldız", ProductionYear = 2007, ReleaseYear = 2007, Genre = "Komedi", Director = "Yüksel Aksu", Platform = "Kanal D" },
                new Series { Name = "Arka Sokaklar", ProductionYear = 2004, ReleaseYear = 2004, Genre = "Polisiye, Dram", Director = "Orhan Oğuz", Platform = "Kanal D" },
                new Series { Name = "Aşk-ı Memnu", ProductionYear = 2008, ReleaseYear = 2008, Genre = "Dram, Romantik", Director = "Hilal Saral", Platform = "Kanal D" },
                new Series { Name = "Muhteşem Yüzyıl", ProductionYear = 2011, ReleaseYear = 2011, Genre = "Tarihi, Dram", Director = "Mercan Çilingiroğlu", Platform = "Star TV" },
                new Series { Name = "Yaprak Dökümü", ProductionYear = 2006, ReleaseYear = 2006, Genre = "Dram", Director = "Serdar Akar", Platform = "Kanal D" }
            };

            // Kullanıcıdan yeni dizi ekleme
            while (true)
            {
                Console.Write("Yeni bir dizi eklemek ister misiniz? (e/h): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "e") break;

                Console.Write("Dizi adı: ");
                string name = Console.ReadLine();

                Console.Write("Yapım yılı: ");
                int productionYear = int.Parse(Console.ReadLine());

                Console.Write("Yayın yılı: ");
                int releaseYear = int.Parse(Console.ReadLine());

                Console.Write("Türü: ");
                string genre = Console.ReadLine();

                Console.Write("Yönetmen: ");
                string director = Console.ReadLine();

                Console.Write("Platform: ");
                string platform = Console.ReadLine();

                tvSeriesList.Add(new Series
                {
                    Name = name,
                    ProductionYear = productionYear,
                    ReleaseYear = releaseYear,
                    Genre = genre,
                    Director = director,
                    Platform = platform
                });

                Console.WriteLine("Dizi başarıyla eklendi!\n");
            }

            // Komedi dizilerinden yeni liste oluştur
            var comedyList = tvSeriesList
                .Where(s => s.Genre.ToLower().Contains("komedi"))
                .Select(s => new ComedySeries
                {
                    Name = s.Name,
                    Genre = s.Genre,
                    Director = s.Director
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Director)
                .ToList();

            Console.WriteLine("\n  Komedi Dizileri (Yeni Liste) ");
            foreach (var item in comedyList)
            {
                Console.WriteLine($"Adı: {item.Name} / Türü: {item.Genre} / Yönetmen: {item.Director}");
            }

            Console.WriteLine("\n  Tüm Diziler (Sıralı) ");
            var sortedList = tvSeriesList
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Director)
                .ToList();

            foreach (var s in sortedList)
            {
                Console.WriteLine($"Adı: {s.Name}, Yapım: {s.ProductionYear}, Yayın: {s.ReleaseYear}, Tür: {s.Genre}, Yönetmen: {s.Director}, Platform: {s.Platform}");
            }
        }
    }
}
