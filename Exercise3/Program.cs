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
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
