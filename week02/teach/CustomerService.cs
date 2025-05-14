/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 0
        // Scenario: Maxlength set to negative.
        // Expected Result: Maxlength is set to 10 automatically.
        Console.WriteLine("Test 0");
        var customerQ = new CustomerService(-8);
        Console.WriteLine(customerQ._maxSize);

        // Test 1
        // Scenario: No customers added, serve attempted
        // Expected Result: Error: No Customers in Queue.
        Console.WriteLine("Test 1");
        customerQ = new CustomerService(8);
        customerQ.ServeCustomer();

        // Defect(s) Found: Did not check for empty queue.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 2 customers added, serve attempted, customer added, 2 serves attempted.
        // Expected Result: 3 successful serves in order from first added to last. After first serve, one customer should be waiting. After last, none should be.
        Console.WriteLine("Test 2");
        customerQ = new CustomerService(3);
        customerQ.AddNewCustomer();
        customerQ.AddNewCustomer();
        customerQ.ServeCustomer();
        Console.WriteLine(customerQ);
        customerQ.AddNewCustomer();
        customerQ.ServeCustomer();
        customerQ.ServeCustomer();
        Console.WriteLine(customerQ);

        // Defect(s) Found: Emptied queue before retrieving from it.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Maxlength 2, too many customers added.
        // Expected Result: Warning after 2 customers.
        Console.WriteLine("Test 3");
        customerQ = new CustomerService(2);
        customerQ.AddNewCustomer();
        customerQ.AddNewCustomer();
        customerQ.AddNewCustomer();
        customerQ.AddNewCustomer();

        // Defect(s) Found: AddNewCustomer allows for one too many customers in queue.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue. Should not start = _maxsize.
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Check Queue for length > 0
        if (_queue.Count <= 0) {
            Console.WriteLine("Error: No Customers in Queue.");
            return;
        }
        // Save first, delete after
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}