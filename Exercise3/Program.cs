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
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
