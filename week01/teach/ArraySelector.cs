public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select, select.Length);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select, int size)
    {
        var totalList = new int[size];
        var i = 0; var j = 0;

        for (int x = 0; x < size; x++) {
            var selector = select[x];

            if (selector == 1) {
                totalList[x] = list1[i++];
            }
            else if (selector == 2) {
                totalList[x] = list2[j++];
            }
        }

        return totalList;
    }
}