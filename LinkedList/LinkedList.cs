using System.Diagnostics.Metrics;

namespace Classes;

public class Node<T>{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value){
        Value = value;
        Next = null;
    }
}

public class LinkedList<T>{
    private Node<T> _head;

    public LinkedList(T value){
        _head = new Node<T>(value);
    }

    public void add(T value){
        Node<T> node = new Node<T>(value);
        Node<T> n = _head;
        while(n.Next != null){
            n = n.Next;
        }
        n.Next = node;
    }

    public void remove(T value){
        Node<T> n = _head;
        Node<T> next = n.Next;

        while(next.Next != null){
            if(next.Value.Equals(value)){
                n.Next = next.Next;
                break;
            }else{
                n = next;
                next = next.Next;
            }
        }
    }

    public void addIn(T value, int index){
        Node<T> n = new Node<T>(value);
        Node<T> h = _head;
        for(int i = 0; i < index; i++){
            h = h.Next;
        }

        Node<T> tmp = h.Next;
        h.Next = n;
        n.Next = tmp;
    }

    public int size(){
        Node<T> n = _head;
        int size = 0;

        while(n.Next != null){
            n = n.Next;
            size++;
        }

        return size;
    }

    public T search(int index){
        Node<T> n = _head;
        int counter = 0;
        while(n.Next != null && counter < index){
            n = n.Next;
        }

        return n.Value;
    }

    public T getLast(int index){
        Node<T> n = _head;
        while(n.Next != null){
            n = n.Next;
        }

        return n.Value;
    }

    public void printList(){
        Node<T> n = _head;
        while(n.Next != null){
            Console.WriteLine(n.Value);
            n = n.Next;
        }
        Console.WriteLine(n.Value);
    }

}