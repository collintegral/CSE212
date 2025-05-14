using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enter one item; check; dequeue one item; check.
    // Expected Result: One item; empty.
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var first = new PriorityItem("First", 1);
        priorityQueue.Enqueue(first.Value, first.Priority);
        Assert.AreEqual($"[{first}]", priorityQueue.ToString());

        var highPrio = priorityQueue.Dequeue();
        Assert.AreEqual(first.Value, highPrio);
    }

    [TestMethod]
    // Scenario: Dequeue with no items.
    // Expected Result: Queue is empty error
    // Defect(s) Found: None.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Queue four items in reverse order; dequeue each.
    // Expected Result: Dequeue as if a stack.
    // Defect(s) Found: Dequeue did not check final slot; Dequeue did not clear slot.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        var first = new PriorityItem("First", 1);
        var second = new PriorityItem("Second", 2);
        var third = new PriorityItem("Third", 3);
        var fourth = new PriorityItem("Fourth", 4);
        PriorityItem[] tests = [first, second, third, fourth];

        priorityQueue.Enqueue(first.Value, first.Priority);
        priorityQueue.Enqueue(second.Value, second.Priority);
        priorityQueue.Enqueue(third.Value, third.Priority);
        priorityQueue.Enqueue(fourth.Value, fourth.Priority);

        var i = 3;
        for (; i >= 0; i--) {
            var result = priorityQueue.Dequeue();
            Assert.AreEqual(tests[i].Value, result);
        }
    }

    [TestMethod]
    // Scenario: Queue four items with all but 1st at top priority.
    // Expected Result: Dequeue 2, 3, 4, 1.
    // Defect(s) Found: Dequeue was removing last instance of top priority, not first.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        var first = new PriorityItem("First", 1);
        var second = new PriorityItem("Second", 4);
        var third = new PriorityItem("Third", 4);
        var fourth = new PriorityItem("Fourth", 4);
        PriorityItem[] tests = [second, third, fourth, first];

        priorityQueue.Enqueue(first.Value, first.Priority);
        priorityQueue.Enqueue(second.Value, second.Priority);
        priorityQueue.Enqueue(third.Value, third.Priority);
        priorityQueue.Enqueue(fourth.Value, fourth.Priority);

        var i = 0;
        for (; i < 4; i++) {
            var result = priorityQueue.Dequeue();
            Assert.AreEqual(tests[i].Value, result);
        }
    }
}