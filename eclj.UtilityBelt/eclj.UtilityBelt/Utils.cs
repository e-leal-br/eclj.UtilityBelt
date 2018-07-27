namespace eclj.UtilityBelt
{
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    //  TODO: Enhance and document better
    public static class Utils
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
