using Library.Core;

namespace MainApp
{
    class MainApplication
    {
        //   static ArrayList bookArray;
        // static ArrayList clientArray;
        static void Main(string[] args)
        {
            List<Book> bookArray = new List<Book>(){
            new Book("1","Dune", "Frank Herbert",Genre.SCIFI),
            new Book("2","Project Hail Mary","Andy Weir",Genre.SCIFI),
            new Book("3","Beach Read","Emily Henry",Genre.ROMANCE),
            new Book("4","Fifth Season","N.K. Jesmin",Genre.FANTASY)
            };
            List<Client> clientArray = new List<Client>()
            {
                new Client("1","client1","12345678",new Address("Blvd Iuliu Maniu","Bucuresti","Bucuresti",12),"client1@gmail.com"),
                new Client("2","client2","asdfghjkl",new Address("Mihail Moxa","Bucuresti","Bucuresti",11),"client2@gmail.com"),
                new Client("3","client3","aefhkeghg",new Address("Bld Vladimirescu","Ploiesti","Prahova",15),"client3@gmail.com")
            };
            List<Lend> lends = new List<Lend>()
            {
                new Lend(bookArray[0],clientArray[0],new DateTime(2020,3,15),new DateTime(2020,3,22)),
                new Lend(bookArray[1],clientArray[1],new DateTime(2020,3,15),new DateTime(2020,3,22)),
                new Lend(bookArray[0],clientArray[2],new DateTime(2020,3,5),new DateTime(2020,3,14))
            };

            LendBookService lendBookService = new LendBookService();
            lendBookService.LendBookToClient(bookArray[0], clientArray[1], new DateTime(2020, 3, 23), new DateTime(2020, 4, 2),lends);
            try
            {
                UserSignUpService userSignUpService = new UserSignUpService();
                userSignUpService.LogIn("client@gmail.com", "12345678", clientArray);
            }
            catch(WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch(NonExistentUserException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

     

    }
}
