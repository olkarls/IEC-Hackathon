using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace GarbageCollectr.Web.Business
{
    public class CognitiveServicesCaller
    {
        public static AnalysisResult AnalyzeImage(string filename, string subscriptionKey)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters
            var uri = "https://api.projectoxford.ai/vision/v1.0/analyze?visualFeatures=Categories,Tags,Description,Faces,ImageType,Color,Adult";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'url':" + "https://garbagecollectrstorage.blob.core.windows.net/" + filename + "}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;
                Trace.WriteLine(result);
                var analysisResult = JsonConvert.DeserializeObject<AnalysisResult>(result);
                Trace.WriteLine(analysisResult);
                return analysisResult;
            }

        }

        /// <summary>
        /// The class for analysis result.
        /// </summary>
        public class AnalysisResult
        {
            /// <summary>
            /// Gets or sets the request identifier.
            /// </summary>
            /// <value>
            /// The request identifier.
            /// </value>
            public Guid RequestId { get; set; }

            /// <summary>
            /// Gets or sets the metadata.
            /// </summary>
            /// <value>
            /// The metadata.
            /// </value>
            public Metadata Metadata { get; set; }

            /// <summary>
            /// Gets or sets the type of the image.
            /// </summary>
            /// <value>
            /// The type of the image.
            /// </value>
            public ImageType ImageType { get; set; }

            /// <summary>
            /// Gets or sets the color.
            /// </summary>
            /// <value>
            /// The color.
            /// </value>
            public Color Color { get; set; }

            /// <summary>
            /// Gets or sets the adult.
            /// </summary>
            /// <value>
            /// The adult.
            /// </value>
            public Adult Adult { get; set; }

            /// <summary>
            /// Gets or sets the categories.
            /// </summary>
            /// <value>
            /// The categories.
            /// </value>
            public Category[] Categories { get; set; }

            /// <summary>
            /// Gets or sets the faces.
            /// </summary>
            /// <value>
            /// The faces.
            /// </value>
            public Face[] Faces { get; set; }

            /// <summary>
            /// Gets or sets the tags for the image.
            /// </summary>
            /// <value>
            /// The list of tags.
            /// </value>
            public Tag[] Tags { get; set; }

            /// <summary>
            /// Gets or sets the image description.
            /// </summary>
            /// <value>
            /// The description.
            /// </value>
            public Description Description { get; set; }
        }


        /// <summary>
        /// A single caption for an image, along with a confidence score.
        /// </summary>
        public class Caption
        {
            /// <summary>
            /// Gets or sets the caption text.
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// Gets or sets the confidence score for the caption text.
            /// </summary>
            public double Confidence { get; set; }
        }

        /// <summary>
        /// The class for image description.
        /// </summary>
        public class Description
        {
            /// <summary>
            /// Gets or sets the caption type.
            /// </summary>
            public string[] Tags { get; set; }

            /// <summary>
            /// Gets or sets the collection of captions.
            /// </summary>
            public Caption[] Captions { get; set; }
        }

        /// <summary>
        /// Tag discerned through image analysis.
        /// </summary>
        public class Tag
        {
            /// <summary>
            /// Name of the tag.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Confidence score for the tag.
            /// </summary>
            public double Confidence { get; set; }

            /// <summary>
            /// Optional hint/details for this tag.
            /// </summary>
            public string Hint { get; set; }
        }

        /// <summary>
        /// The class for face.
        /// </summary>
        public class Face
        {
            /// <summary>
            /// Gets or sets the age.
            /// </summary>
            /// <value>
            /// The age.
            /// </value>
            public int Age { get; set; }

            /// <summary>
            /// Gets or sets the gender.
            /// </summary>
            /// <value>
            /// The gender.
            /// </value>
            public string Gender { get; set; }

            /// <summary>
            /// Gets or sets the face rectangle.
            /// </summary>
            /// <value>
            /// The face rectangle.
            /// </value>
            public FaceRectangle FaceRectangle { get; set; }
        }

        /// <summary>
        /// The face rectangle entity.
        /// </summary>
        public class FaceRectangle
        {
            /// <summary>
            /// Gets or sets the width.
            /// </summary>
            /// <value>
            /// The width.
            /// </value>
            public int Width { get; set; }

            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            /// <value>
            /// The height.
            /// </value>
            public int Height { get; set; }

            /// <summary>
            /// Gets or sets the left.
            /// </summary>
            /// <value>
            /// The left.
            /// </value>
            public int Left { get; set; }

            /// <summary>
            /// Gets or sets the top.
            /// </summary>
            /// <value>
            /// The top.
            /// </value>
            public int Top { get; set; }
        }

        /// <summary>
        /// The class for metadata.
        /// </summary>
        public class Metadata
        {
            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            /// <value>
            /// The height.
            /// </value>
            public int Height { get; set; }

            /// <summary>
            /// Gets or sets the width.
            /// </summary>
            /// <value>
            /// The width.
            /// </value>
            public int Width { get; set; }

            /// <summary>
            /// Gets or sets the format.
            /// </summary>
            /// <value>
            /// The format.
            /// </value>
            public string Format { get; set; }
        }


        /// <summary>
        /// Image Type
        /// </summary>
        public class ImageType
        {
            /// <summary>
            /// Gets or sets the type of the clip art.
            /// </summary>
            /// <value>
            /// The type of the clip art.
            /// </value>
            public int ClipArtType { get; set; }

            /// <summary>
            /// Gets or sets the type of the line drawing.
            /// </summary>
            /// <value>
            /// The type of the line drawing.
            /// </value>
            public int LineDrawingType { get; set; }
        }

        /// <summary>
        /// The class for color.
        /// </summary>
        public class Color
        {
            /// <summary>
            /// Gets or sets the color of the accent.
            /// </summary>
            /// <value>
            /// The color of the accent.
            /// </value>
            public string AccentColor { get; set; }

            /// <summary>
            /// Gets or sets the dominant color foreground.
            /// </summary>
            /// <value>
            /// The dominant color foreground.
            /// </value>
            public string DominantColorForeground { get; set; }

            /// <summary>
            /// Gets or sets the dominant color background.
            /// </summary>
            /// <value>
            /// The dominant color background.
            /// </value>
            public string DominantColorBackground { get; set; }

            /// <summary>
            /// Gets or sets the dominant colors.
            /// </summary>
            /// <value>
            /// The dominant colors.
            /// </value>
            public string[] DominantColors { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is binary image.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this instance is binary image; otherwise, <c>false</c>.
            /// </value>
            public bool IsBWImg { get; set; }
        }

        /// <summary>
        /// The class for adult.
        /// </summary>
        public class Adult
        {
            /// <summary>
            /// Gets or sets a value indicating whether this instance is adult content.
            /// </summary>
            /// <value>
            /// <c>true</c> if this instance is adult content; otherwise, <c>false</c>.
            /// </value>
            public bool IsAdultContent { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is racy content.
            /// </summary>
            /// <value>
            /// <c>true</c> if this instance is racy content; otherwise, <c>false</c>.
            /// </value>
            public bool IsRacyContent { get; set; }

            /// <summary>
            /// Gets or sets the adult score.
            /// </summary>
            /// <value>
            /// The adult score.
            /// </value>
            public double AdultScore { get; set; }

            /// <summary>
            /// Gets or sets the racy score.
            /// </summary>
            /// <value>
            /// The racy score.
            /// </value>
            public double RacyScore { get; set; }
        }

        /// <summary>
        /// The class for category.
        /// </summary>
        public class Category : NameScorePair
        {
            /// <summary>
            /// Detail for this category, when available.
            /// The type will be dictated by the model invoked.
            /// </summary>
            public object Detail { get; set; }
        }

        /// <summary>
        /// The class for a tag.
        /// </summary>
        public class NameScorePair
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the score.
            /// </summary>
            /// <value>
            /// The score.
            /// </value>
            public double Score { get; set; }
        }
    }
}
