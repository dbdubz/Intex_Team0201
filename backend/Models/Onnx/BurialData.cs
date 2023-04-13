using Microsoft.ML.OnnxRuntime.Tensors;

namespace Onnx2.Model
{
    public class BurialData
    {
        public float squarenorthsouth { get; set; }
        public float burialdepth { get; set; }
        public float facebundles { get; set; }
        public float southtohead { get; set; }
        public float squareeastwest { get; set; }
        public float goods { get; set; }
        public float westtohead { get; set; }
        public float samplescollected { get; set; }
        public float buriallength { get; set; }
        public float westtofeet { get; set; }
        public float southtofeet { get; set; }
        public float northsouth_N { get; set; }
        public float eastwest_E { get; set; }
        public float eastwest_W { get; set; }
        public float adultsubadult_A { get; set; }
        public float adultsubadult_C { get; set; }
        public float wrapping_B { get; set; }
        public float wrapping_H { get; set; }
        public float wrapping_W { get; set; }
        public float area_NE { get; set; }
        public float area_NW { get; set; }
        public float area_SE { get; set; }
        public float area_SW { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_N { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            squarenorthsouth, burialdepth, facebundles, southtohead,
            squareeastwest, goods, westtohead, samplescollected, buriallength, westtofeet, southtofeet, northsouth_N
            , eastwest_E, eastwest_W, adultsubadult_A, adultsubadult_C, wrapping_B, wrapping_H, wrapping_W, area_NE
            , area_NW, area_SE, area_SW, ageatdeath_A, ageatdeath_C, ageatdeath_I, ageatdeath_N
            };
            int[] dimensions = new int[] { 1, 27 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
