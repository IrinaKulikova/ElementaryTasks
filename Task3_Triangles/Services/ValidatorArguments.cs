using Task3_Triangles.Enums;
using Task3_Triangles.Services.Interfaces;

namespace Task3_Triangles.Services
{
    public class ValidatorArguments : IValidatorArguments
    {
        public bool Check(string[] args)
        {
            return ValidCount(args) && ArgsAreFloats(args);
        }

        private bool ArgsAreFloats(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (i % (int)ValidCountArguments.Triangle != 0)
                {
                    if (!float.TryParse(args[i], out float arg))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidCount(string[] args)
        {
            return args.Length % (int)ValidCountArguments.Triangle == 0;
        }
    }
}
