/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Enqueue and Dequeue single customer
        // Expected Result: Customer should be served correctly
        Console.WriteLine("Test 1");
        var cs = new CustomerService(2);
        cs.AddNewCustomer("John Doe", "123", "Issue 1");
        cs.ServeCustomer();  // Expected: John Doe (123) : Issue 1
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Enqueue customers up to max size
        // Expected Result: All customers should be added and served in order
        Console.WriteLine("Test 2");
        cs = new CustomerService(2);
        cs.AddNewCustomer("Alice", "124", "Issue 2");
        cs.AddNewCustomer("Bob", "125", "Issue 3");
        cs.ServeCustomer();  // Expected: Alice (124) : Issue 2
        cs.ServeCustomer();  // Expected: Bob (125) : Issue 3
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Exceeding queue size
        // Expected Result: Should display error when exceeding size
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        cs.AddNewCustomer("Charlie", "126", "Issue 4");
        cs.AddNewCustomer("Dave", "127", "Issue 5");  // Expected: Error message
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Dequeue from an empty queue
        // Expected Result: Should display an error when queue is empty
        Console.WriteLine("Test 4");
        cs = new CustomerService(1);
        cs.ServeCustomer();  // Expected: Error message
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0) {
            _maxSize = 10;
        } else {
            _maxSize = maxSize;
        }
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class. Its real name is CustomerService.Customer.
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Adds a new customer to the queue.
    /// </summary>
    public void AddNewCustomer(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Serves the next customer in the queue.
    /// </summary>
    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Provides a string representation of the customer service queue.
    /// </summary>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
