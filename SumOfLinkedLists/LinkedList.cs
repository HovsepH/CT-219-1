public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head;

    public void Append(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node lastNode = head;
        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }

        lastNode.Next = newNode;
    }
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }

        Console.WriteLine("null");
    }

    public int Length()
    {
        int length = 0;
        Node current = head;
        while (current != null)
        {
            length++;
            current = current.Next;
        }
        return length;
    }

    public bool Search(int data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == data)
                return true;

            current = current.Next;
        }
        return false;
    }

    public static LinkedList AddTwoLists(LinkedList l1, LinkedList l2)
    {
        var resultList = new LinkedList();
        var node1 = l1.head;
        var node2 = l2.head;
        int value1 = 0;
        int value2 = 0;
        int resultValue = 0;
        int carry = 0;

        while (node1 != null || node2 != null)
        {
            value1 = (node1 != null) ? node1.Data : 0;
            value2 = (node1 != null) ? node2.Data : 0;
            resultValue = value1 + value2 + carry;
            resultList.Append(resultValue % 10);
            carry = resultValue / 10;

            node1 = (node1 != null) ? node1.Next : null;
            node2 = (node2 != null) ? node2.Next : null;
        }

        return resultList;
    }

    public int ComputeHash()
    {
        const int prime = 31;
        int hash = 1;
        Node current = head;
       
        while (current != null)
        {
            hash = hash * prime + current.Data;

            current = current.Next;
        }

        return hash;
    }
}
