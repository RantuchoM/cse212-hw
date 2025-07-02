public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Create an array of doubles with the size of 'length'.
        var multiples = new double[length];
        // 2. Use a loop to iterate from 0 to length - 1.
        for (int i = 0; i < length; i++)
        {
            // 3. In each iteration, calculate the multiple of 'number' by multiplying it with the current index + 1.
            multiples[i] = number * (i + 1);
        }
        // 4. Return the array of multiples.
        return multiples;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Validate the input to ensure 'amount' is within the valid range (1 to data.Count).
        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be an integer between 1 and the size of the list.");
        }
        // 2. Create a new list to temporarily hold the rotated values.
        List<int> rotated = new List<int>(data.Count);
        // 3. Append the last 'amount' elements of 'data' to the new list.
        rotated.AddRange(data.GetRange(data.Count - amount, amount));
        // 4. Append the first 'data.Count - amount' elements of 'data' to the new list.
        rotated.AddRange(data.GetRange(0, data.Count - amount));
        // 5. Clear the original 'data' list.
        data.Clear();
        // 6. Add the elements from the 'rotated' list back to 'data'.
        data.AddRange(rotated);
    }
}
