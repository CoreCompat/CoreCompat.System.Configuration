
namespace System.IO {
	public static class Path2
    {

        internal static readonly char[] PathSeparatorChars;
        static Path2()
        {

            PathSeparatorChars = new char[] {
                Path.DirectorySeparatorChar,
                Path.AltDirectorySeparatorChar,
                Path.VolumeSeparatorChar
            };
        }

        internal static string InsecureGetFullPath (string path)
		{
            return Path.GetFullPath(path);
		}

		// required for FileIOPermission (and most proibably reusable elsewhere too)
		// both path MUST be "full paths"
		static internal bool IsPathSubsetOf (string subset, string path)
		{
			if (subset.Length > path.Length)
				return false;

			// check that everything up to the last separator match
			int slast = subset.LastIndexOfAny (PathSeparatorChars);
			if (String.Compare (subset, 0, path, 0, slast) != 0)
				return false;

			slast++;
			// then check if the last segment is identical
			int plast = path.IndexOfAny (PathSeparatorChars, slast);
			if (plast >= slast) {
				return String.Compare (subset, slast, path, slast, path.Length - plast) == 0;
			}
			if (subset.Length != path.Length)
				return false;

			return String.Compare (subset, slast, path, slast, subset.Length - slast) == 0;
		}
	}
}