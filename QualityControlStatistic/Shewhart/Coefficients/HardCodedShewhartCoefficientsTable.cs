namespace QualityControlStatistic.Shewhart.Coefficients
{
    public class RussianStandartShewhartCoefficientsTable : IShewhartCoefficientsTable
    {
        public double A2(int groupSize)
        {
            //TODO: chek boundary values
            return A2values[groupSize - minimalGroupSize];
        }

        public double A4(int groupSize)
        {
            return A4values[groupSize - minimalGroupSize];
        }

        public double D3(int groupSize)
        {
            return D3values[groupSize - minimalGroupSize];
        }

        public double D4(int groupSize)
        {
            return D4values[groupSize - minimalGroupSize];
        }

        public double d2(int groupSize)
        {
            return d2values[groupSize - minimalGroupSize];
        }

        private readonly double[] A1values = new[] {2.121, 1.732, 1.5, 1.342, 1.225, 1.134, 1.061, 1, 0.949, 0.905, 0.866, 0.832, 0.802, 0.775, 0.75, 0.728, 0.707, 0.688, 0.671, 0.655, 0.64, 0.626, 0.612, 0.6};
        private readonly double[] A2values = new[] {1.88, 1.023, 0.729, 0.577, 0.483, 0.419, 0.373, 0.337, 0.308, 0.285, 0.266, 0.249, 0.235, 0.223, 0.212, 0.203, 0.194, 0.187, 0.18, 0.173, 0.167, 0.162, 0.157, 0.153};
        private readonly double[] A3values = new[] {2.659, 1.954, 1.628, 1.427, 1.287, 1.182, 1.099, 1.032, 0.975, 0.927, 0.886, 0.85, 0.817, 0.789, 0.763, 0.739, 0.718, 0.698, 0.68, 0.663, 0.647, 0.633, 0.619, 0.606};
        private readonly double[] A4values = new[] {1.88, 1.19, 0.80, 0.69, 0.55, 0.51, 0.43, 0.41, 0.36};

        private readonly double[] B3values = new[] {0, 0, 0, 0, 0.03, 0.118, 0.185, 0.239, 0.284, 0.321, 0.354, 0.382, 0.406, 0.428, 0.448, 0.466, 0.482, 0.497, 0.51, 0.523, 0.534, 0.545, 0.555, 0.565};
        private readonly double[] B4values = new[] {3.267, 2.568, 2.266, 2.089, 1.97, 1.882, 1.815, 1.761, 1.716, 1.679, 1.646, 1.618, 1.594, 1.572, 1.552, 1.534, 1.518, 1.503, 1.49, 1.477, 1.466, 1.455, 1.445, 1.434};
        private readonly double[] B5values = new[] {0, 0, 0, 0, 0.029, 0.113, 0.179, 0.232, 0.276, 0.313, 0.346, 0.374, 0.399, 0.421, 0.44, 0.458, 0.475, 0.49, 0.504, 0.516, 0.528, 0.539, 0.549, 0.559};
        private readonly double[] B6values = new[] {2.606, 2.276, 2.088, 1.964, 1.874, 1.806, 1.751, 1.707, 1.669, 1.637, 1.61, 1.585, 1.563, 1.544, 1.526, 1.511, 1.496, 1.483, 1.47, 1.459, 1.448, 1.438, 1.429, 1.42};

        private readonly double[] D1values = new[] {0, 0, 0, 0, 0, 0.204, 0.388, 0.547, 0.687, 0.811, 0.922, 1.025, 1.118, 1.203, 1.282, 1.356, 1.424, 1.487, 1.549, 1.605, 1.659, 1.71, 1.759, 1.806};
        private readonly double[] D2values = new[] {3.686, 4.358, 4.696, 4.918, 5.078, 5.204, 5.306, 5.393, 5.469, 5.535, 5.594, 5.647, 5.696, 5.741, 5.782, 5.82, 5.856, 5.891, 5.921, 5.951, 5.979, 6.006, 6.031, 6.056};
        private readonly double[] D3values = new[] {0, 0, 0, 0, 0, 0.076, 0.136, 0.184, 0.223, 0.256, 0.283, 0.307, 0.328, 0.347, 0.363, 0.378, 0.391, 0.403, 0.415, 0.425, 0.434, 0.443, 0.451, 0.459};
        private readonly double[] D4values = new[] {3.267, 2.574, 2.282, 2.114, 2.004, 1.924, 1.864, 1.816, 1.777, 1.744, 1.717, 1.693, 1.672, 1.653, 1.637, 1.622, 1.608, 1.597, 1.585, 1.575, 1.566, 1.557, 1.548, 1.541};

        private readonly double[] C4values = new[] {0.7979, 0.8886, 0.9213, 0.94, 0.9515, 0.9594, 0.965, 0.9693, 0.9727, 0.9754, 0.9776, 0.9794, 0.981, 0.9823, 0.9835, 0.9845, 0.9854, 0.9862, 0.9869, 0.9876, 0.9882, 0.9887, 0.9892, 0.9896};
        private readonly double[] C4RevercedValues = new[] {1.2533, 1.1284, 1.0854, 1.0638, 1.051, 1.0423, 1.0363, 1.0317, 1.0281, 1.0252, 1.0229, 1.021, 1.0194, 1.018, 1.0168, 1.0157, 1.0148, 1.014, 1.0133, 1.0126, 1.0119, 1.0114, 1.0109, 1.0105}; // 1/C_4

        private readonly double[] d2values = new[] {1.128, 1.693, 2.059, 2.326, 2.534, 2.704, 2.847, 2.97, 3.078, 3.173, 3.258, 3.336, 3.407, 3.472, 3.532, 3.588, 3.64, 3.689, 3.735, 3.778, 3.819, 3.858, 3.895, 3.931};
        private readonly double[] d2revercedValues = new[] {0.8865, 0.5907, 0.4857, 0.4299, 0.3946, 0.3698, 0.3512, 0.3367, 0.3249, 0.3152, 0.3069, 0.2998, 0.2935, 0.288, 0.2831, 0.2784, 0.2747, 0.2711, 0.2677, 0.2647, 0.2618, 0.2592, 0.2567, 0.2544}; // 1/d_2

        private int minimalGroupSize = 2;
    }
}