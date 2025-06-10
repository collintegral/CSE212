using System.Formats.Asn1;
using System.Runtime.CompilerServices;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        bool present = false;
        if (value == Data) present = true;
        else if (value < Data && Left is not null)
        {
            present = Left.Contains(value);
        }
        else if (value > Data && Right is not null)
        {
            present = Right.Contains(value);
        }
        return present;
    }

    public int GetHeight()
    {
        int lH = 0, rH = 0;
        if (Left is not null) lH = Left.GetHeight();

        if (Right is not null) rH = Right.GetHeight();
        
        if (lH > rH) return 1 + lH;
        else return 1 + rH;
    }
}