using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: All individual elements with different levels of priority are added to the queue.
    // Expected Result: The queue should return the elements in order of their priority when dequeued.
    // Defect(s) Found: It wasn't removing the element when dequeing, causing the same element to be returned multiple times.
    public void TestPriorityQueue_Unique()
    {

        var elem1 = new PriorityItem("Element 1", 2);
        var elem2 = new PriorityItem("Element 2", 1);
        var elem3 = new PriorityItem("Element 3", 4);
        var elem4 = new PriorityItem("Element 4", 3);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(elem1.Value, elem1.Priority);
        priorityQueue.Enqueue(elem2.Value, elem2.Priority);
        priorityQueue.Enqueue(elem3.Value, elem3.Priority);
        priorityQueue.Enqueue(elem4.Value, elem4.Priority);

        PriorityItem[] expectedItems = { elem3, elem4, elem1, elem2 };

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            var dequeuedValue = priorityQueue.Dequeue();
            Assert.AreEqual(expectedItems[i].Value, dequeuedValue);
            i++;
        }


    }

    [TestMethod]
    // Scenario: Multiple elements with the same priority are added to the queue.
    // Expected Result: The elements should be returned in the order they were added when dequeued, respecting the priority and order.
    // Defect(s) Found: The elements are not retrieved in the order they were ipmlemented in the highest priority. 
    //    I should add a case where the priority values are equal so it doesn't override the highPriorityIndex
    public void TestPriorityQueue_Multiple()
    {
        var elem1 = new PriorityItem("Element 1", 2);
        var elem2 = new PriorityItem("Element 2", 1);
        var elem3 = new PriorityItem("Element 3", 4);
        var elem4 = new PriorityItem("Element 4", 3);
        var elem5 = new PriorityItem("Element 5", 4); // Same priority as elem3
        var elem6 = new PriorityItem("Element 6", 2); // Same priority as elem1
        var elem7 = new PriorityItem("Element 7", 1); // Same priority as elem2
        var elem8 = new PriorityItem("Element 8", 2); // Same priority as elem6&1

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(elem1.Value, elem1.Priority);
        priorityQueue.Enqueue(elem2.Value, elem2.Priority);
        priorityQueue.Enqueue(elem3.Value, elem3.Priority);
        priorityQueue.Enqueue(elem4.Value, elem4.Priority);
        priorityQueue.Enqueue(elem5.Value, elem5.Priority);
        priorityQueue.Enqueue(elem6.Value, elem6.Priority);
        priorityQueue.Enqueue(elem7.Value, elem7.Priority);
        priorityQueue.Enqueue(elem8.Value, elem8.Priority);

        PriorityItem[] expectedItems = { elem3, elem5, elem4, elem1, elem6, elem8, elem2, elem7 };

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            var dequeuedValue = priorityQueue.Dequeue();
            Assert.AreEqual(expectedItems[i].Value, dequeuedValue);
            i++;
        }
    }

    [TestMethod]
    // Scenario: The queue is empty when Dequeue is called.
    // Expected Result: An InvalidOperationException should be thrown.  
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

}