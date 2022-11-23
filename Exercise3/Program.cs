using System;

namespace Exercise3
{
    class Node
    {
        //Deklarasi variabel
        public int rollNumber;
        public string name;
        //Membuat node untuk next circular list
        public Node next;
    }

    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        //Method untuk mencari apakah node yang dimaksud ada di dalam list
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); //jika node ditemukan
            }
            if (rollNo == LAST.rollNumber) //jika node berada di akhir
                return true;
            else
                return (false); //jika node tidak ditemukan
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        //method untuk membaca isi list
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node curretntNode;
                curretntNode = LAST.next;

                //Jika current node tidak sama dengan nilai LAST
                while (curretntNode != LAST)
                {
                    Console.Write(curretntNode.rollNumber + "   " + curretntNode.name + "\n");
                    curretntNode = curretntNode.next;
                }
                Console.Write(LAST.rollNumber + "   " + LAST.name + "\n");
            }
        }

        //Method untuk node pertama
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else Console.WriteLine("\nThe first record in the list is: \n\n" + LAST.next.rollNumber + "   " + LAST.next.name);
        }

        //Method untuk menambahkan node baru
        public void addNode()
        {
            int rolNo;
            string name;
            Console.Write("\nEnter the student number: ");
            rolNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the student name: ");
            name = Console.ReadLine();

            Node newNode = new Node();
            newNode.rollNumber = rolNo;
            newNode.name = name;

            //jika node yang akan disisipkan adalah node pertama
            if (LAST == null)
            {
                LAST = newNode;
                newNode.next = LAST;
                return;
            }

            //jika node yang akan disisipkan berada di awal list
            if (rolNo <= LAST.next.rollNumber)
            {
                if ((LAST != null) && (rolNo == LAST.next.rollNumber))
                {
                    Console.WriteLine("\nDuplicate student numbers not allowed\n");
                    return;
                }
                newNode.next = LAST.next;
                LAST.next = newNode;
            }

            //Membuat node prev, curr
            Node prev, curr;

            curr = LAST.next;
            prev = LAST.next;

            while ((prev != LAST) && (rolNo >= curr.rollNumber))
            {
                if (rolNo == curr.rollNumber)
                {
                    Console.WriteLine("\nDuplicate student numbers not allowed\n");
                    return;
                }
                prev = curr;
                curr = curr.next;
            }

            //jika node akan dimasukan di akhir list
            if (rolNo > LAST.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
                LAST = newNode;
                return;
            }
            newNode.next = curr;
            prev.next = newNode;
        }

        //Method untuk menghapus node tertentu di dalam list
        public bool delNode(int rollNo)
        {
            Node prev, curr;
            prev = LAST.next;
            curr = LAST.next;

            if (Search(rollNo, ref prev, ref curr) == false)
                return false;

            prev.next = curr.next;

            if (curr == LAST.next)
                LAST.next = curr.next;

            while ((rollNo != curr.rollNumber) && (prev.rollNumber != LAST.rollNumber))
            {
                prev = curr;
                curr = curr.next;
            }

            if (curr == LAST)
            {
                prev.next = LAST.next;
                LAST = prev;
            }
            return true;
        }

        static void Main(string[] args)
        {
            //Membuat objek baru untuk class CircularList
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty.");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
