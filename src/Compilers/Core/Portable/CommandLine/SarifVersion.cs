// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.CodeAnalysis
{
    /// <summary>
    /// Specifies the version of the SARIF log file to produce.
    /// </summary>
    public enum SarifVersion
    {
        /// <summary>
        /// The original, non-standardized version of the SARIF format.
        /// </summary>
        V1_0_0,

        /// <summary>
        /// The first standardized version of the SARIF format.
        /// </summary>
        V2_1_0,

        /// <summary>
        /// The default SARIF version, which is v1.0.0 for compatibility with
        /// previous versions of the compiler.
        /// </summary>
        Default = V1_0_0,

        /// <summary>
        /// The latest supported SARIF version.
        /// </summary>
        Latest = int.MaxValue
    }

    public static class SarifVersionFacts
    {
        /// <summary>
        /// Try to parse the SARIF log file version from a string.
        /// </summary>
        public static bool TryParse(string version, out SarifVersion result)
        {
            if (version == null)
            {
                result = SarifVersion.Default;
                return true;
            }

            switch (CaseInsensitiveComparison.ToLower(version))
            {
                case "default":
                    result = SarifVersion.Default;
                    return true;

                case "latest":
                    result = SarifVersion.Latest;
                    return true;

                case "1":
                case "1.0":
                case "1.0.0":
                    result = SarifVersion.V1_0_0;
                    return true;

                case "2":
                case "2.1":
                case "2.1.0":
                    result = SarifVersion.V2_1_0;
                    return true;

                default:
                    result = SarifVersion.Default;
                    return false;
            }
        }
    }
}