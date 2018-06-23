using System;
using System.Linq;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Data
{
    public static class DbInitializer
    {
        public static void Initializer(this ViVuStoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            // init seed data
            var categories = new Category[]
            {
                new Category()
                {
                    Name = "Literature & Fiction",
                    Description = "Literature & Fiction",
                },
                new Category()
                {
                    Name = "Self Help",
                    Description = "Self Help"
                },
                new Category()
                {
                    Name = "Truyện Tranh, Manga, Comic",
                    Description = "Truyện Tranh, Manga, Comic"
                }
            };

            foreach (Category category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var publishers = new Publisher[]
            {
                new Publisher()
                {
                    Name = "Nhà xuất bản Trẻ",
                    Description = "Dù chiếm một phần không nhỏ trong các đầu sách của nhà xuất bản Trẻ là sách kiến thức phổ thông, thường thức đời sống, mảng sách hư cấu (sách dịch lẫn sách trong nước) mới có những ấn phẩm để lại dấu ấn. Nhà xuất bản Trẻ cũng là bệ phóng cho những tên tuổi văn học Việt Nam đương đại như Nguyễn Nhật Ánh hay Nguyễn Ngọc Tư; hoặc giới thiệu nhiều tác giả nổi tiếng trên thế giới đến Việt Nam như Mario Puzo (Bố già), Paul Auster, Thomas Mann (qua Tủ sách Cánh cửa mở rộng), J. K. Rowling (qua bộ sách Harry Potter)...",
                },
                new Publisher()
                {
                    Name = "Nhà xuất bản Kim Đồng",
                    Description = "Nhà xuất bản Kim Đồng là nhà xuất bản chuyên sản xuất và phát hành sách, văn hóa phẩm dành cho trẻ em lớn nhất tại Việt Nam với hơn 1.000 đầu sách mỗi năm thuộc nhiều thể loại như văn học, lịch sử, khoa học, truyện tranh,... Bên cạnh việc hợp tác với các cá nhân vá tổ chức trong nước, Nhà xuất bản Kim Đồng còn hợp tác với hơn 70 nhà xuất bản khác trên khắp thế giới, đặc biệt các nhà xuất bản như Dorling Kindersley, HarperCollins UK, Simon and Schuster UK, Dami International, Shogakukan, Nhà xuất bản Seoul,...",
                },
                new Publisher()
                {
                    Name = "First News - Trí Việt",
                    Description = "First News là thương hiệu quốc tế của Công ty Văn hóa Sáng tạo Trí Việt, là một trong những thương hiệu xuất bản uy tín và được bạn đọc yêu thích nhất tại Việt Nam. Ra đời từ năm 1994, First News đã trải qua 20 năm kinh nghiệm trong lĩnh vực xuất bản sách, với trên 2.000 cuốn sách giá trị ra mắt bạn đọc trên tất cả các lĩnh vực khác nhau, trong đó có 90% các đầu sách được chuyển ngữ từ các tác giả nổi tiếng trên thế giới. Đây là một trong những đơn vị sớm nhất ký và tuân thủ Công ước Berne năm 2003.",
                }
            };

            foreach (Publisher publisher in publishers)
            {
                context.Publishers.Add(publisher);
            }
            context.SaveChanges();

            var authors = new Author[]
            {
                new Author()
                {
                    Name = "J. K. Rowling",
                    Description = "Joanne \"Jo\" Rowling, sinh ngày 31 tháng 7 năm 1965, bút danh là J. K. Rowling, và Robert Galbraith. Cư ngụ tại thủ đô Edinburgh,Scotland là tiểu thuyết gia người Anh, tác giả bộ truyện giả tưởng nổi tiếng Harry Potter với bút danh J. K. Rowling.",
                },
                new Author()
                {
                    Name = "Dale Carnegie",
                    Description = "Dale Breckenridge Carnegie(24 tháng 11 năm 1888 – 1 tháng 11 năm 1955) là một nhà văn và nhà thuyết trình Mỹ. Ra đời trong cảnh nghèo đói tại một trang trại ở Missouri, ông là tác giả cuốn Đắc Nhân Tâm, được xuất bản lần đầu năm 1936, một cuốn sách thuộc hàng bán chạy nhất và được biết đến nhiều nhất cho đến tận ngày nay.",
                },
                new Author()
                {
                    Name = "Aoyama Gosho",
                    Description = "Aoyama Gōshō (青山 あおやま 剛昌 ごうしょう (Thanh Sơn Cương Xương)?), tên khai sinh là Aoyama Yoshimasa (青山 あおやま 剛昌 よしまさ (Thanh Sơn Cương Xương)? - giữ nguyên Kanji nhưng thay cách đọc), sinh ngày 21 tháng 6 năm 1963 tại Hokuei tỉnh Tottori, Nhật Bản (trước đây còn được biết tới là Daiei, tỉnh Tottori). Ông là một nhà sáng tác truyện tranh, được biết đến với bộ truyện tranh Thám tử lừng danh Conan.",
                },
                new Author()
                {
                    Name = "Eiichiro Oda",
                    Description = "Oda Eiichiro (尾田 栄一郎 Oda Eiichirō?, Vĩ Điền Vinh Nhất Lang) (sinh ngày 1 tháng 1 năm 1975 tại thành phố Kumamoto, tỉnh Kumamoto) là một họa sĩ truyện tranh người Nhật Bản, hiện đang sáng tác cho nhà xuất bản Shūeisha. Tác phẩm tiêu biểu: One Piece.",
                },
                new Author()
                {
                    Name = "Fujiko.F.Fujio",
                    Description = "Fujiko Fujio (藤子 不二雄, ふじこ ふじお) (Đằng Tử Bất Nhị Hùng) IPA: /ɸɯdʒiko ɸɯdʒio/ là bút danh chung của hai nghệ sĩ manga Nhật Bản. Năm 1987, họ chia tay để theo đuổi con đường sáng tác riêng rẽ và trở thành \"Fujiko F. Fujio\" và \"Fujiko Fujio (A)\". Trong số các tác phẩm của cả hai, tác phẩm được biết đến rộng rãi nhất là Doraemon.",
                }
             };

            foreach (Author author in authors)
            {
                context.Authors.Add(author);
            }
            context.SaveChanges();

            var books = new Book[]
            {
#region First News - Trí Việt

                new Book()
                {
                    Title = "How To Win Friends And Influence People",
                    Description = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/ts/product/1f/b7/1c/01f8604e67cf0b97b22ec4c94bc2a756.jpg",
                    TotalPages = 274,
                    Price = 169M,
                    ReleaseDate = new DateTimeOffset(2004,07,26,0,0,0, new TimeSpan()),
                    BookDimensions = "17.9 x 11.2 cm",
                    Publisher = publishers.Single(p=>p.Name==("First News - Trí Việt")),
                    Author = authors.Single(a=>a.Name==("Dale Carnegie")),
                    Category = categories.Single(c=>c.Name==("Self Help"))
                },
                new Book()
                {
                    Title = "How To Stop Worrying And Start Living",
                    Description = "Quẳng Gánh Lo Đi Và Vui Sống là cuốn sách mà cái tên đã nói lên tất cả nội dung chuyển tải trên những trang giấy. Bất kỳ ai đang sống đều sẽ có những lo lắng thường trực về học hành, công việc, những hoá đơn, chuyện nhà cửa,... Cuộc sống không dễ dàng giải thoát bạn khỏi căng thẳng, ngược lại, nếu quá lo lắng, bạn có thể mắc bệnh trầm cảm. Quẳng Gánh Lo Đi Và Vui Sống khuyên bạn hãy khóa chặt dĩ vãng và tương lai lại để sống trong cái phòng kín mít của ngày hôm nay. Mọi vấn đề đều có thể được giải quyết, chỉ cần bạn bình tĩnh và xác định đúng hành động cần làm vào đúng thời điểm.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/ts/product/26/21/67/2fe1c93f32e3bd1e8728af8a994320fe.jpg",
                    TotalPages = 432,
                    Price = 37M,
                    ReleaseDate = new DateTimeOffset(1997,06,26,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("First News - Trí Việt")),
                    Author = authors.Single(a=>a.Name==("Dale Carnegie")),
                    Category = categories.Single(c=>c.Name==("Self Help"))
                },

                #endregion

#region Nhà xuất bản Trẻ

                new Book()
                 {
                     Title = "Harry Potter And The Sorcerer's Stone",
                     Description = "Khi một lá thư được gởi đến cho cậu bé Harry Potter bình thường và bất hạnh, cậu khám phá ra một bí mật đã được che giấu suốt cả một thập kỉ. Cha mẹ cậu chính là phù thủy và cả hai đã bị lời nguyền của Chúa tể Hắc ám giết hại khi Harry mới chỉ là một đứa trẻ, và bằng cách nào đó, cậu đã giữ được mạng sống của mình. Thoát khỏi những người giám hộ Muggle không thể chịu đựng nổi để nhập học vào trường Hogwarts, một trường đào tạo phù thủy với những bóng ma và phép thuật, Harry tình cờ dấn thân vào một cuộc phiêu lưu đầy gai góc khi cậu phát hiện ra một con chó ba đầu đang canh giữ một căn phòng trên tầng ba. Rồi Harry nghe nói đến một viên đá bị mất tích sở hữu những sức mạnh lạ kì, rất quí giá, vô cùng nguy hiểm, mà cũng có thể là mang cả hai đặc điểm trên.",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/e5/1d/e1/78a5040e782cb40c1e45b80f4e8fe68e.jpg",
                     TotalPages = 336,
                     Price = 179M,
                     ReleaseDate = new DateTimeOffset(1997,06,26,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Chamber Of Secrets",
                     Description = "Vào năm học thứ 2 tại trường Hogwarts, Harry và các bạn tiếp tục đối mặt với những bài học thú vị mới và những bí mật mới. Người kế vị Slytherin đã gây ra nỗi kinh hoàng trong trường, với lời đồn đại về căn phòng chứa bí mật. Cuộc phiêu lưu của Harry và hai người bạn, Ron và Hermione, hấp dẫn hơn bao giờ hết nhờ minh họa sống động của họa sĩ Jim Kay. Harry Potter và Phòng chứa bí mật là tập 2 trong bộ sách Harry Potter với phiên bản có tranh minh họa.",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/28/cf/ef/d289d04bb3ea3676b0643768eff6292b.jpg",
                     TotalPages = 368,
                     Price = 179M,
                     ReleaseDate = new DateTimeOffset(1998,07,02,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Prisoner Of Azkaban",
                     Description = "Harry Potter may mắn sống sót đến tuổi 13, sau nhiều cuộc tấn công của Chúa tể hắc ám. Nhưng hy vọng có một học kỳ yên ổn với Quidditch của cậu đã tiêu tan thành mây khói khi một kẻ điên cuồng giết người hàng loạt vừa thoát khỏi nhà tù Azkaban, với sự lùng sục của những cai tù là giám ngục. Dường như trường Hogwarts là nơi an toàn nhất cho Harry lúc này. Nhưng có phải là sự trùng hợp khi cậu luôn cảm giác có ai đang quan sát mình từ bóng đêm, và những điềm báo của giáo sư Trelawney liệu có chính xác? Câu chuyện được kể với trí tưởng tượng bay bổng, sự hài hước bất tận có thể quyến rũ cả người lớn lẫn trẻ em.",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/d5/55/e9/c7cd957d5abcd262b6058ca327fd5cfa.jpg",
                     TotalPages = 464,
                     Price = 179M,
                     ReleaseDate = new DateTimeOffset(1999,07,08,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Goblet Of Fire",
                     Description = "Khi giải Quidditch Thế giới bị cắt ngang bởi những kẻ ủng hộ Chúa tể Voldemort và sự trở lại của Dấu hiệu hắc ám khủng khiếp, Harry ý thức được rõ ràng rằng, Chúa tể Voldemort đang ngày càng mạnh hơn. Và để trở lại thế giới phép thuật, Chúa tể hắc ám cần phải đánh bại kẻ duy nhất sống sót từ lời nguyền chết chóc của hắn - Harry Potter. Vì lẽ đó, khi Harry bị buộc phải bước vào giải đấu Tam Pháp thuật uy tín nhưng nguy hiểm, cậu nhận ra rằng trên cả chiến thắng, cậu phải giữ được mạng sống của mình. Bốn năm của Harry cũng như của chúng tôi ở trường Hogwarts thật vui nhộn, một thế giới đầy hài hước cùng nhiều hoạt động thú vị.",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/06/dc/bd/f5fd839d7ad2e415a90b4356f77cf4b8.jpg",
                     TotalPages = 768,
                     Price = 207M,
                     ReleaseDate = new DateTimeOffset(2000,07,08,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Order Of The Phoenix",
                     Description = "Harry tức giận vì bị bỏ rơi ở nhà Dursley trong dịp hè, cậu ngờ rằng Chúa tể hắc ám Voldemort đang tập hợp lực lượng, và vì cậu có nguy cơ bị tấn công, những người Harry luôn coi là bạn đang cố che giấu tung tích cậu. Cuối cùng, sau khi được giải cứu, Harry khám phá ra rằng giáo sư Dumbledore đang tập hợp lại Hội Phượng Hoàng – một đoàn quân bí mật đã được thành lập từ những năm trước nhằm chống lại Chúa tể Voldemort. Tuy nhiên, Bộ Pháp thuật không ủng hộ Hội Phượng Hoàng, những lời bịa đặt nhanh chóng được đăng tải trên Nhật báo Tiên tri – một tờ báo của giới phù thủy, Harry lo ngại rằng rất có khả năng cậu sẽ phải gánh vác trách nhiệm chống lại cái ác một mình. ‘Hoang đường nhưng không hoang tưởng, trí tưởng tượng của Rowling cùng sự táo bạo của cô đã tạo cho cô một phong cách riêng.’ - The Times.",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/eb/7f/91/7df0e35db0bc4e596d0d4244b0917056.jpg",
                     TotalPages = 688,
                     Price = 207M,
                     ReleaseDate = new DateTimeOffset(2003,06,21,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Half-Blood Prince",
                     Description = "Đây là năm thứ 6 của Harry Potter tại trường Hogwarts. Trong lúc những thế lực hắc ám của Voldemort gieo rắc nỗi kinh hoàng và sợ hãi ở khắp nơi, mọi chuyện càng lúc càng trở nên rõ ràng hơn đối với Harry, rằng cậu sẽ sớm phải đối diện với định mệnh của mình. Nhưng liệu Harry đã sẵn sàng vượt qua những thử thách đang chờ đợi phía trước? Trong cuộc phiêu lưu tăm tối và nghẹt thở nhất của mình, J.K.Rowling bắt đầu tài tình tháo gỡ từng mắc lưới phức tạp mà cô đã mạng lên, cũng là lúc chúng ta khám phá ra sự thật về Harry, cụ Dumblebore, thầy Snape và, tất nhiên, Kẻ Chớ Gọi Tên Ra… ‘Diễn biến nhanh, huyền bí, hấp dẫn và chặt chẽ trong từng chi tiết.'",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/ts/product/8a/80/b8/bb5beb6139eaaa66c832c5f039d72ced.jpg",
                     TotalPages = 716,
                     Price = 207M,
                     ReleaseDate = new DateTimeOffset(2005,07,16,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Deathly Hallows",
                     Description = "Harry đang chờ đợi ở trường Privet Drive. Hội Phượng Hoàng sắp đến hộ tống nó ra đi an toàn, gắng hết sức không để cho Voldemort và bọn tay chân hắn biết được. Nhưng sau đó Harry sẽ làm gì? Làm cách nào nó có thể hoàn thành nhiệm vụ cực kỳ quan trọng và dường như bất khả thi mà giáo sự Dumbledore đã giao lại cho nó?",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/96/03/b1/b2bf654981872c536e7517c6a8db185a.jpg",
                     TotalPages = 784,
                     Price = 234M,
                     ReleaseDate = new DateTimeOffset(2007,07,21,0,0,0, new TimeSpan()),
                     BookDimensions = "14.5 x 20.5 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
                 new Book()
                 {
                     Title = "Fantastic Beasts And Where To Find Them",
                     Description = "J.K. Rowling's screenwriting debut is captured in this exciting hardcover edition of the Fantastic Beasts and Where to Find Them screenplay. When Magizoologist Newt Scamander arrives in New York, he intends his stay to be just a brief stopover. However, when his magical case is misplaced and some of Newt's fantastic beasts escape, it spells trouble for everyone… Fantastic Beasts and Where to Find Them marks the screenwriting debut of J.K. Rowling, author of the beloved and internationally bestselling Harry Potter books. Featuring a cast of remarkable characters, this is epic, adventure-packed storytelling at its very best. Whether an existing fan or new to the wizarding world, this is a perfect addition to any reader's bookshelf.",
                     ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/e5/1d/e1/78a5040e782cb40c1e45b80f4e8fe68e.jpg",
                     TotalPages = 304,
                     Price = 419M,
                     ReleaseDate = new DateTimeOffset(2001,03,01,0,0,0, new TimeSpan()),
                     BookDimensions = "15 x 3 x 22.1 cm",
                     Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Trẻ")),
                     Author = authors.Single(a=>a.Name==("J. K. Rowling")),
                     Category = categories.Single(c=>c.Name==("Literature & Fiction"))
                 },
#endregion

#region Nhà xuất bản Kim Đồng

                 // Aoyama Gosho
                new Book()
                {
                    Title = "Thám Tử Lừng Danh Conan Tập 1",
                    Description = "Thám Tử Lừng Danh Conan Tập 1 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/c/o/conan1_2.jpg",
                    TotalPages = 61,
                    Price = 16M,
                    ReleaseDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Aoyama Gosho")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Thám Tử Lừng Danh Conan Tập 2",
                    Description = "Thám Tử Lừng Danh Conan Tập 2 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/c/o/conan2_2.jpg",
                    TotalPages = 62,
                    Price = 16M,
                    ReleaseDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Aoyama Gosho")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Thám Tử Lừng Danh Conan Tập 3",
                    Description = "Thám Tử Lừng Danh Conan Tập 3 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/c/o/conan3_2.jpg",
                    TotalPages = 63,
                    Price = 16M,
                    ReleaseDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Aoyama Gosho")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Thám Tử Lừng Danh Conan Tập 4",
                    Description = "Thám Tử Lừng Danh Conan Tập 4 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/c/o/conan4_4.jpg",
                    TotalPages = 64,
                    Price = 16M,
                    ReleaseDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Aoyama Gosho")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Thám Tử Lừng Danh Conan Tập 5",
                    Description = "Thám Tử Lừng Danh Conan Tập 5 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/c/o/conan5_2.jpg",
                    TotalPages = 65,
                    Price = 16M,
                    ReleaseDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Aoyama Gosho")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },

                // Eiichiro Oda

                new Book() {
                    Title = "One Piece - Tập 1",
                    Description = "One Piece - Tập 1 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/o/n/onpice-tap-1.jpg",
                    TotalPages = 196,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "One Piece - Tập 2",
                    Description = "One Piece - Tập 2 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/o/n/one-picee-tap-2.jpg",
                    TotalPages = 190,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "One Piece - Tập 3",
                    Description = "One Piece - Tập 3 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/o/n/one-piece-tap-3.jpg",
                    TotalPages = 186,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "One Piece - Tập 4",
                    Description = "One Piece - Tập 4 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/o/n/one-piece-tap-4.jpg",
                    TotalPages = 199,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "One Piece - Tập 5",
                    Description = "One Piece - Tập 5 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/o/n/one-piece-tap-5.jpg",
                    TotalPages = 194,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "One Piece - Tập 6",
                    Description = "One Piece - Tập 6 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/media/bookpreview/c1/0e/449399/files/OEBPS/Images/img693.gif",
                    TotalPages = 191,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "One Piece - Tập 7",
                    Description = "One Piece - Tập 7 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/o/n/one-piece-tap-7.jpg",
                    TotalPages = 192,
                    Price = 17M,
                    ReleaseDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Eiichiro Oda")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },

                //Fujiko.F.Fujio
                new Book()
                {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 1",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 1 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/d/o/doraemon-dai-tuyen-tap---truyen-dai-t1.u4972.d20170531.t164902.633493.jpg",
                    TotalPages = 625,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2017,05,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 2",
                    Description = "Fujiko F Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 2 - Lâu đài dưới đáy biển, Chuyến phiêu lưu vào xứ quỷ, Cuộc chiến vũ trụ...!! 3 Chuyến phiêu lưu đầy kịch tính tiếp theo của Nobita và nhóm bạn sẽ đưa các bạn tới những vùng đất kì diệu đầy hoài niệm của tuổi thơ!! Đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko,Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. Bắt đầu từ tháng 10, 2 Series Doraemon truyện ngắn & dài thuộc Đại Tuyển tập Fujiko F Fujio sẽ ra mắt đều đặn mỗi tháng 1 cuốn xen kẽ. Đừng bỏ lỡ nhé các Fan của Mèo Ú!!",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/1/0/10.u5762.d20171018.t104146.65072.jpg",
                    TotalPages = 621,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2017,10,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 3",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 3 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/ts/product/1c/95/e7/b7776078b6d09fee03c095a3cd330750.jpg",
                    TotalPages = 623,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2017,11,05,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 4",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 4 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/5c/d0/ea/c305ffaffe121f995805ef27f7fa1394.jpg",
                    TotalPages = 615,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2018,01,22,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 5",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 5 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/95/4b/28/b27be6374bd146a152c999e70ad6740d.jpg",
                    TotalPages = 655,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2018,04,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Doraemon - Truyện Ngắn Tập 1",
                    Description = "Doraemon - Truyện Ngắn Tập 1",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/d/o/doraemon-tap-1.jpg",
                    TotalPages = 190,
                    Price = 14M,
                    ReleaseDate = new DateTimeOffset(2014,02,25,0,0,0, new TimeSpan()),
                    BookDimensions = "11.3 x 17.6 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 1",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 1 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/d/o/doraemon-dai-tuyen-tap---truyen-dai-t1.u4972.d20170531.t164902.633493.jpg",
                    TotalPages = 625,
                    Price = 169M,
                    ReleaseDate = new DateTimeOffset(2017,05,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 1 (Ấn Bản Kỉ Niệm 60 Năm NXB Kim Đồng)",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 1 (Ấn Bản Kỉ Niệm 60 Năm NXB Kim Đồng) Bộ sách là phiên bản tập hợp đầy đủ nhất các truyện ngắn Doraemon, trong đó đã bao gồm những truyện ngắn quen thuộc trong bộ 45 tập cùng những sáng tác chưa từng ra mắt của tác giả Fujiko F Fujio được đăng rải rác trên các tạp chí dành cho lứa tuổi Nhi Đồng tại Nhật Bản. Với độ dày gần 800 trang cho tập 1, đi kèm là những trang màu cùng lời tâm sự của tác giả chưa từng được công bố ở bất cứ đâu, đây chắc chắn sẽ là một trong những bộ sách ấn tượng trong series Doraemon nói riêng, cũng như loạt sách kỉ niệm 60 năm của NXB Kim Đồng. Đồng thời đây cũng là ấn phẩm đánh dấu chặng đường 25 năm đồng hành cùng độc giả Việt Nam của chú Mèo Ú đến từ tương lai Doraemon. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/media/catalog/product/d/o/doraemon-dai-tuyen-tap---truyen-ngan.u4972.d20170531.t163159.716408.jpg",
                    TotalPages = 790,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2017,05,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 2",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 2 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/ts/product/7e/62/50/57ba64fa6280e27c318d4988bcd9ed82.jpg",
                    TotalPages = 644,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2017,11,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 3",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 3 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/550x550/ts/product/21/fd/b3/688fdb5e64b37a9d01c9dd6cdb2327ca.jpg",
                    TotalPages = 654,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2018,01,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 4",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 4 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/e3/e4/9a/3bfe28a493e948fa83254dddaa3c426d.jpg",
                    TotalPages = 622,
                    Price = 130M,
                    ReleaseDate = new DateTimeOffset(2018,03,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                },
                new Book() {
                    Title = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 5",
                    Description = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 5 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageThumbnailUrl = "https://vcdn.tikicdn.com/cache/w1200/ts/product/69/4d/7d/f677c9c1e2000eb60fd0a31c481147ff.jpg",
                    TotalPages = 612,
                    Price = 123M,
                    ReleaseDate = new DateTimeOffset(2018,05,25,0,0,0, new TimeSpan()),
                    BookDimensions = "14.5 x 20.5 cm",
                    Publisher = publishers.Single(p=>p.Name==("Nhà xuất bản Kim Đồng")),
                    Author = authors.Single(a=>a.Name==("Fujiko.F.Fujio")),
                    Category = categories.Single(c=>c.Name==("Truyện Tranh, Manga, Comic"))
                }
#endregion
            };

            foreach (Book book in books)
            {
                var bookInDatabase = context.Books.Where(
                    p =>
                    p.Category.Id == book.CategoryId
                    && p.Author.Id == book.AuthorId
                    && p.Publisher.Id == p.PublisherId)
                    .SingleOrDefault();

                if (bookInDatabase == null)
                    context.Books.Add(book);
            }
            context.SaveChanges();
        }
    }
}
