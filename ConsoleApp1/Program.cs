using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    using Sawao;

    namespace Sawao
    {
        abstract class User : ISharable
        {
            private string name;
            private string id;
            private static int count = 0;

            /*プロパティ*/
            public string Name
            {
                get { return this.name; }  //getter 
                set
                {
                    if (value != "")
                    {
                        this.name = value;
                    }
                }  //setter 
            }
            public string Id
            {
                get { return this.id; }
                set { this.id = value; }
            }


            /*コンストラクタ*/
            public User(string name, string id)
            {
                this.name = name;
                this.id = id;
                count++;
            }
            public User() : this("Taro Honda", "J0999999")
            {
            }
            public User(string name) : this(name, "J0999999")
            {
                this.name = name;
            }
            public abstract void SayHi(); //オーバーライドする際には、される側の関数にvirtualとつけなければならない

            public static void GetCount()
            {
                Console.WriteLine($"インスタンス数:{count}");
            }

            public void Share()
            {
                Console.WriteLine("Now Sharing.....");
            }

        }

        class Japanese : User
        {
            public Japanese(string name, string id) : base(name, id)
            {
            }
            public Japanese(string name) : base(name)
            {

            }
            public Japanese() : base()
            {

            }
            public override void SayHi()
            {
                Console.WriteLine($"こんにちは{this.Name}");
            }
        }

        class American : User
        {
            public American(string name, string id) : base(name, id)
            {

            }
            public American(string name) : base()
            {

            }
            public American() : base()
            {

            }
            public override void SayHi()
            {
                Console.WriteLine($"Hi!{this.Name}");
            }
        }

        class AdminUser : User
        {
            public AdminUser(string name, string id) : base(name, id + "a") //これで自動的にa付き職番になる
            {
            }

            public void SayHello()
            {
                Console.WriteLine($"Hello, {this.Name}");
            }

            public override void SayHi()
            {
                Console.WriteLine($"[admin]Hi! {this.Name}");
                Console.WriteLine($"[admin]Your UserID is {this.Id}");
            }
        }

        class Team
        {
            private string[] members = new string[3];
            /*インデクサ*/
            public string this[int i]
            {
                get { return this.members[i]; }
                set { this.members[i] = value; }
            }
        }

        interface ISharable
        {
            //インターフェイスは抽象クラスと同じなので中身の実装はいらない
            //また、自動的にアクセス修飾子はpublicになるのでvoidの前に何か書くこともない
            void Share();
        }

        class MyData<T>
        {
            public void GetThree(T x)
            {
                Console.WriteLine(x);
                Console.WriteLine(x);
                Console.WriteLine(x);
            }
        }

        struct Point
        {
            public float X { get; }
            public float Y { get; }
            public Point(float x, float y)
            {
                X = x;
                Y = y;
            }
            public void GetInfo()
            {
                Console.WriteLine($"(x, y) = ({X},{Y})");
            }
        }

        class MyException : Exception
        {
            public MyException(string msg) : base(msg)
            {

            }
        }

        delegate void MyDelegate();

        delegate void MyEventHandler();

        class MyButton
        {
            public event MyEventHandler MyEvent;    //こうしてeventをつけておくとこのクラス内でしか使用できませんという意味に
            public void OnClick()
            {
                if(MyEvent != null)
                {
                    MyEvent();
                }
                
            }
        }
    }

    class Program
    {
        /*メモ
           型推論：var型を使うことで型を推測して使ってくれる
           float型の注意点
           →少数の後ろに大文字か小文字のfをつけなければならない
           →ちなみにdouble型は特につけなくてもいいので、double型を使うのが主流らしい
             */
         static void StopConsole()
        {
            const string message = "プログラムを続けるには何かキーを押してください";
            Console.WriteLine(message);
            Console.ReadKey();
        }
         static void HelloWorld()
        {
            Console.WriteLine("-----------HelloWorld編----------------*/");
            var word = "Hello World!";
            Console.WriteLine(word);
            Console.WriteLine("Hello" + "World");
            Console.WriteLine("Hel\nlo wo\trld ");

            var name = "taguchi";
            var score = 53.2;

            Console.WriteLine(string.Format("{0} [{1}]", name, score));
            Console.WriteLine($"{0} [{1}]", name, score);       //こうすると{0}[{1}]と表示されてしまう。
            Console.WriteLine($"{name} [{score}]");
            Console.WriteLine($"{name, -10} [{score, 10}]");
            Console.WriteLine($"{name,-10} [{score + 25,10:0.00}]");
            Console.WriteLine("------------------------------------------");
        }
        static void ConditionalBranch()
        {
            Console.WriteLine("-------------演算・条件分岐編----------------*/");

           Console.WriteLine("数値を入力してください");
            var score2 = int.Parse(Console.ReadLine());

            if(score2 >= 80)
            {
                Console.WriteLine("Great!");
            }
            else if(score2 >= 60)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.WriteLine("so so ...");
            }

            Console.WriteLine((score2 > 80) ? "Great" : "so so....");
            Console.WriteLine("------------------------------------------");
        }
        static void TestSwitch()
        {
            Console.WriteLine("----------------------switch編-------------------------*/");
            Console.WriteLine("red/green/blue/yeloowのどれかを入力してください");
             var signal = Console.ReadLine();

             switch (signal)
             {
                 case "red":
                     Console.WriteLine("Stop!!");
                     break;
                 case "green":
                 case "blue":
                     Console.WriteLine("Go!!");
                     break;
                 case "yellow":
                     Console.WriteLine("Caution!!");
                     break;
                 default:
                     Console.WriteLine("Wrong signal");
                     break;
             }
            Console.WriteLine("------------------------------------------");
        }
        static void TestRepitition()
        {
            Console.WriteLine("----------------繰り返し編----------------------");
            

            var i = 100;
            while(i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
          //元々条件式が偽の場合でも、一度は実行されるのがdo-while構文
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 10);

            for (i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    continue;
                }
                Console.WriteLine(i);

            }

            Console.WriteLine("------------------------------------------");
        }
        static void TestArray()
        {
            /*------------------配列編---------------------*/
            //int[] score = new int[3];
            //score[0] = 10;
            //score[1] = 30;
            //score[2] = 20;

            //int[] scores = { 10, 30, 20 };
            var scores = new[] { 10, 30, 40 };

            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
            /*----------------------------------------------*/
        }
        static string HelloWorld2() => "HelloWorld";
        static void SayHi(string name, int age = 23)
        {
            Console.WriteLine($"hi! {name} ({age})");
        }
        static void ClassTest()
        {
            //SayHi("Steve", 28);
            //SayHi("Bob");
            //SayHi(age: 28, name: "Sawao");
            /*
            User sawao = new User("Keita Sawao", "J0118386");
            Console.WriteLine(sawao.Name);
            Console.WriteLine(sawao.Id);
            sawao.SayHi();
            sawao.Name = "";
            sawao.Id = "";
            Console.WriteLine(sawao.Name);
            Console.WriteLine(sawao.Id);

            User user = new User();
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Id);
            user.SayHi();

            User test = new User("Test Taro");
            Console.WriteLine(test.Name);
            Console.WriteLine(test.Id);
            test.SayHi();

            AdminUser Bob = new AdminUser("Bob", "J0111111");
            Console.WriteLine(Bob.Name);
            Console.WriteLine(Bob.Id);
            Bob.SayHi();
            Bob.SayHello();*/
        }
        static void IndexaTest()
        {
            Team teamCMF = new Team();
            teamCMF[0] = "Hanzato";
            teamCMF[1] = "Koseki";
            teamCMF[2] = "Sawao";

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(teamCMF[i]);
            }
        }
        static void AbstractClassTest()
        {
            Japanese user1 = new Japanese();
            Console.WriteLine(user1.Name);
            Console.WriteLine(user1.Id);
            User.GetCount();
            Japanese sawao = new Japanese("Keita Sawao", "J0118386");
            User.GetCount();
            American bob = new American("Bob");
            Console.WriteLine(bob.Id);
            bob.SayHi();
            User.GetCount();
            AdminUser tom = new AdminUser("Tom", "J0111111");
            User.GetCount();
        }
       static void GenericTest()
        {
            MyData<string> str = new MyData<string>();
            str.GetThree("test");

            MyData<double> v = new MyData<double>();
            v.GetThree(23.3);
        }
        static void KozotaiTest()
        {
            Point p1 = new Point(0.0f, 0.0f);
            Point p2 = new Point(14.3f, 28.9f);

            p1.GetInfo();
            p2.GetInfo();
        }
        static void Div(int a, int b)
        {
            try
            {
                if(a/b < 0)
                {
                    throw new MyException("マイナスやんか！");
                }
                Console.WriteLine(a / b);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(MyException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("------------end-------------");
            }
            
        }
        static void Debug( string str)
        {
            Console.WriteLine(str);
        }
        static void Debug(double v)
        {
            Console.WriteLine(v);
        }
        static void Debug(int v)
        {
            Console.WriteLine(v);
        }
        static void Debug(bool v)
        {
            Console.WriteLine(v);
        }
        static void DelegateTest1()
        {
            MyDelegate ShowMessage;
            ShowMessage = TestArray;
            ShowMessage += TestRepitition;
            ShowMessage();

            ShowMessage -= TestRepitition;
            ShowMessage();
        }
        static void DelegateTest2()
        {
            MyDelegate ShowMessage;
            //匿名メソッド
            ShowMessage = delegate
            {
                Console.WriteLine("hi!");
            };
            //ラムダ式:引数 => 処理
            ShowMessage += () =>
            {
                Console.WriteLine("Hello");
            };
            //ラムダ式短縮系（※ただし、メソッドが一行の時に限る）
            ShowMessage += () => Debug("なんの意味があるんだ！");

            ShowMessage();
        }
        static void EventTest()
        {
            MyButton btn = new MyButton();
            btn.MyEvent += () => Debug("このとき+=か-=しか使用できません");
            btn.MyEvent += () => Debug("注意してください");

            btn.OnClick();
        }
        static void ListTest()
        {
            List<int> scores = new List<int>();
            scores.Add(20);
            scores.Add(30);
            scores.Add(10);

            scores[1] = 100;
            Debug(scores.Count);

            foreach (var score in scores)
            {
                Debug(score);
            }
        }
        static void HashsetTest()
        {
            HashSet<int> answers = new HashSet<int>() { 3, 5, 8 };
            answers.Add(10);
            answers.Remove(3);
            Debug(answers.Contains(3));
            foreach (var answer in answers)
            {
                Debug(answer);
            }
        }
        static void DictionaryTest()
        {
            Dictionary<string, int> users = new Dictionary<string, int>()
            {
                {"Sawao", 28 },
                {"Tsurumaki", 26 },

            };
            users.Add("dotinstall", 40);
            //Debug(users["Sawao"]);
            users["Sawao"] = 48;

            foreach (KeyValuePair<string, int> user in users)
            {
                Console.WriteLine($"{user.Key}:{user.Value}");
            }

        }

        static void Main(string[] args)
        {
            List<double> prices = new List<double>() { 53.2, 48.2, 32.4 };
            //SQL
            /*
            var results = from price in prices
                          where price * 1.08 > 50
                          select price * 1.08;*/
            //method
            var results = prices
                .Select(n => n * 1.08)
                .Where(n => n > 50);

            foreach(var result in results)
            {
                Debug(result);
            }

            StopConsole();
        }
    }
}
