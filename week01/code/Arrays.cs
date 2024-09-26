public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
    //Plan for Arrays
    //Step 1: Create an array to hold the multiples.
    //Step 2: Loop through each position in the array.
    //Step 3: Compute the multiple by multiplying number with i + 1.
    //Step 4: Return the array filled with multiples.
    public static double[] MultiplesOf(double number, int length)
    {
    
        // Step 1: Create an array to hold the multiples
        double[] multiplesArray = new double[length];

        // Step 2: Loop through each position in the array
        for (int i = 0; i < length; i++)
        {

        // Step 3: Compute the multiple by multiplying 'number'
        multiplesArray[i] = number * (i + 1);
        }

        // Step 4: Return the array filled with multiples
        return multiplesArray;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    //Plan for Solving a Complicated Problem Using a List
    //Step 1: Calculate the effective rotation amount.
    //Step 2: Reverse the entire list.
    //Step 3: Reverse the first amount elements.
    //Step 4: Reverse the remaining elements from 'amount' to the end.
    //Step 5: The original list 'data' is now rotated in place.
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the effective rotation amount
        int n = data.Count;
        amount = amount % n;
        if (amount == 0) return;

        // Step 2: Reverse the entire list
        data.Reverse(0, n);

        // Step 3: Reverse the first amount elements
        data.Reverse(0, amount);

        // Step 4: Reverse the remaining elements from 'amount' to the end
        data.Reverse(amount, n - amount);

        // Step 5: The original list 'data' is now rotated in place
    }
}
