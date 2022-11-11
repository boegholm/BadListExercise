namespace BadListExercise.Tests
{
    static class BLExt
    {
        public static BadList ToBadList(this int[] ia)
        {
            var bl = new BadList();
            foreach (var v in ia)
                bl.Add(v);
            return bl;
        }
        public static List<int> ToList(this BadList bl) => Enumerable.Range(0, bl.Length).Select(bl.Get).ToList();
    }
}