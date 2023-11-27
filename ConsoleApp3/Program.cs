using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
namespace N1
{
    public delegate int CarSpeednTime(int a, int b);
    public delegate int CarFinish(int d);
    public abstract class car
    {
        public string type { set; get; }
        public int speed { set; get; }
        public int time { set; get; }
        public abstract void driving();
        public abstract int km(int a, int b);
        public abstract string finis(int d);
    }
    public class SportCar : car
    {
        public SportCar(string typ, int sped, int tim)
        {
            type = typ;
            speed = sped;
            time = tim;
        }
        public override void driving()
        {
            Console.WriteLine($"{type} со скоростью {speed}км/ч");
        }
        public override int km(int a, int b)
        {
            return (a * b) % 60;
        }
        public event CarFinish finish;
        public override string finis(int d)
        {
            if (finish != null)
            {
                finish(d);
            }
            return ($"{type} финишировал первым");
        }

    }
    public class PassangerCar : car
    {
        public PassangerCar(string typ, int sped, int tim)
        {
            type = typ;
            speed = sped;
            time = tim;
        }
        public override void driving()
        {
            Console.WriteLine($"{type} со скоростью {speed}км/ч");
        }
        public override int km(int a, int b)
        {
            return (a * b) % 60;
        }
        public event CarFinish finish;
        public override string finis(int d)
        {
            if (finish != null)
            {
                finish(d);
            }
            return ($"{type} финишировал первым");
        }

    }
    public class FrieghtCar : car
    {
        public FrieghtCar(string typ, int sped, int tim)
        {
            type = typ;
            speed = sped;
            time = tim;
        }
        public override void driving()
        {
            Console.WriteLine($"{type} со скоростью {speed}км/ч");
        }
        public override int km(int a, int b)
        {
            return (a * b) % 60;
        }
        public event CarFinish finish;
        public override string finis(int d)
        {
            if (finish != null)
            {
                finish(d);
            }
            return ($"{type} финишировал первым");
        }

    }
    public class Bus : car
    {
        public Bus(string typ, int sped, int tim)
        {
            type = typ;
            speed = sped;
            time = tim;
        }
        public override void driving()
        {
            Console.WriteLine($"{type} со скоростью {speed}км/ч");
        }
        public override int km(int a, int b)
        {
            return (a * b) % 60;
        }
        public event CarFinish finish;
        public override string finis(int d)
        {
            if (finish != null)
            {
                finish(d);
            }
            return ($"{type} финишировал первым");
        }

    }
    public class Prog
    {
        static void Main(string[] args)
        {
            int u = 180;
            int t = 1;
            int d = 1000;
            int ressp = 0, respass = 0, resfr = 0, resbus = 0, res1, res2, res3, res4;
            CarSpeednTime dellsp;
            CarSpeednTime dellpass;
            CarSpeednTime dellfr;
            CarSpeednTime dellbus;
            SportCar spcar = new SportCar("Спортивный", u, t);
            PassangerCar passcar = new PassangerCar("Легковой", u, t);
            FrieghtCar frcar = new FrieghtCar("Грузовой", u, t);
            Bus bus = new Bus("Автобус", u, t);
            dellsp = spcar.km;
            dellpass = passcar.km;
            dellfr = frcar.km;
            dellbus = bus.km;
            var rand = new Random();
            for (int i = 0; i < 100000; i++)
            {
                u = rand.Next(0, 180);
                res1 = dellsp(u, t);
                u = rand.Next(0, 180);
                res2 = dellpass(u, t);
                u = rand.Next(0, 180);
                res3 = dellfr(u, t);
                u = rand.Next(0, 180);
                res4 = dellbus(u, t);
                ressp += res1;
                respass += res2;
                resfr += res3;
                resbus += res4;
                if (ressp == 1000 || ressp > 1000)
                {
                    Console.WriteLine(spcar.finis(ressp));
                    break;
                }
                else if (respass == 1000 || respass > 1000)
                {
                    Console.WriteLine(passcar.finis(respass));
                    break;
                }
                else if (resfr == 1000 || resfr > 1000)
                {
                    Console.WriteLine(frcar.finis(resfr));
                    break;
                }
                else if (resbus == 1000 || resbus > 1000)
                {
                    Console.WriteLine(bus.finis(resbus));
                    break;
                }

            }
        }
    }
}
namespace N2
{
    public class Card
    {
        public List<Card> cards { get; set; }
        public string suit { get; set; }
        public int id { get; set; }
        public static bool operator >(Card card,Card card1)
        {
            return card.id > card1.id;
        }
        public static bool operator <(Card card,Card card1)
        {
            return card.id < card1.id;
        }

    }
    public class Player : Card
    {
        public List<Card> cards { get; set; }
        public void show()
        {
            foreach (Card c in cards)
            {
                if (c.id == 11)
                {
                    Console.WriteLine($"В {c.suit}");
                }
                else if (c.id == 12) {
                    Console.WriteLine($"Д {c.suit}");
                }
                else if (c.id == 13) {
                    Console.WriteLine($"К {c.suit}");
                }
                else if (c.id == 14)
                {
                    Console.WriteLine($"Т {c.suit}");
                }
                else
                {
                    Console.WriteLine($"{c.id} {c.suit}");
                }
            }
        }
    }
    public class Game : Card
    {
        public new List<Card> cards { get; set; }
        public void shuffle<Card>(List<Card> cards)
        {
            Random random = new Random();
            for (int i = cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(0, cards.Count);
                Card tmp = cards[j];
                cards[j] = cards[i];
                cards[i] = tmp;
            }
        }// Тасование Фишера-Йетса
        public void dealing(List<Card> cards, List<Card> player, int a)
        {
            for (int i = a; i < a + 16; i++)
            {
                player.Add(cards[i]);
            }
        }
        public void play(List<Card> player1, List<Card> player2) {
            Game pla1 = new Game();
            Game pla2 = new Game();
            pla1.cards = player1;
            pla2.cards = player2;
            int min;
            int scc = 0;
                while ((pla1.cards.Count != 32) || (pla2.cards.Count != 32))
                {
                if (pla1.cards.Count == 32)
                {
                    break;
                }
                else if (pla2.cards.Count == 32)
                {
                    break;
                }
                else
                {
                    if (pla1.cards[id] < pla2.cards[id])
                    {
                        pla2.cards.Add(pla1.cards[id]);
                        pla1.cards.Remove(pla1.cards[id]);
                    }
                    else if (pla1.cards[id] > pla2.cards[id])
                    {
                        pla1.cards.Add(pla2.cards[id]);
                        pla2.cards.Remove(pla2.cards[id]);
                    }
                    else
                    {
                        pla1.cards.Add(pla2.cards[id]);
                        pla2.cards.Remove(pla2.cards[id]);
                    }
                    if (pla1.cards.Count < pla2.cards.Count)
                    {
                        min = pla1.cards.Count;
                    }
                    else
                    {
                        min = pla2.cards.Count;
                    }
                    id++;
                    if (id >= min)
                    {
                        id = 0;
                    }
                    else { }
                    scc++;
                }
                }
                if (pla1.cards.Count == 32)
                {
                Console.WriteLine($"Player 1 Win, кол-во ходов{scc}");
                }
                else
                {
                Console.WriteLine($"Player2 Win, кол-во ходов{scc}");
                }
        }
        public class Prog
        {
            static void Main(string[] args)
            {
                Game game = new Game();
                game.cards = new List<Card>
            {
                new Card {suit="черви",id=6},
                new Card {suit="черви",id=7},
                new Card {suit="черви",id=8},
                new Card {suit="черви",id=9},
                new Card {suit="черви",id=10},
                new Card {suit="черви",id=11},
                new Card {suit="черви",id=12},
                new Card {suit="черви",id=13},
                new Card {suit="черви",id=14},
                new Card {suit="буби",id=6},
                new Card {suit="буби",id=7},
                new Card {suit="буби",id=8},
                new Card {suit="буби",id=9},
                new Card {suit="буби",id=10},
                new Card {suit="буби",id=11},
                new Card {suit="буби",id=12},
                new Card {suit="буби",id=13},
                new Card {suit="буби",id=14},
                new Card {suit="крести",id=6},
                new Card {suit="крести",id=7},
                new Card {suit="крести",id=8},
                new Card {suit="крести",id=9},
                new Card {suit="крести",id=10},
                new Card {suit="крести",id=11},
                new Card {suit="крести",id=12},
                new Card {suit="крести",id=13},
                new Card {suit="крести",id=14},
                new Card {suit="трефы",id=6},
                new Card {suit="трефы",id=7},
                new Card {suit="трефы",id=8},
                new Card {suit="трефы",id=9},
                new Card {suit="трефы",id=10},
                new Card {suit="трефы",id=11},
                new Card {suit="трефы",id=12},
                new Card {suit="трефы",id=13},
                new Card {suit="трефы",id=14},
            };
                game.shuffle(game.cards);
                Game player1 = new Game();
                player1.cards = new List<Card>();
                Game player2 = new Game();
                player2.cards = new List<Card>();
                player1.dealing(game.cards, player1.cards, 0);
                player2.dealing(game.cards, player2.cards, 16);
                Player player11 = new Player();
                player11.cards = player1.cards;
                Player player22 = new Player();
                player22.cards = player2.cards;
                player11.show();
                Console.ReadKey();
                Console.WriteLine();
                player22.show();
                Console.ReadKey();
                game.play(player1.cards,player2.cards);
            }
        }
    }
}