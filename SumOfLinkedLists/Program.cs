var l1 = new LinkedList();
l1.Append(2);
l1.Append(4);
l1.Append(3);
l1.Display();

var l2 = new LinkedList();
l2.Append(5);
l2.Append(6);
l2.Append(4);
l2.Display();

var l3 = LinkedList.AddTwoLists(l1, l2);
l3.Display();

Console.WriteLine("hach code for l1: "+ l1.ComputeHash());
Console.WriteLine("hach code for l2: " + l2.ComputeHash());
Console.WriteLine("hach code for l3: " + l3.ComputeHash());