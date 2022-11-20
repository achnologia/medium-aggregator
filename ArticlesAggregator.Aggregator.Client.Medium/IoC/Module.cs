using System.Net;
using ArticlesAggregator.Aggregator.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ArticlesAggregator.Aggregator.Client.Medium.IoC;

public static class Module
{
    public static IServiceCollection RegisterMediumClient(this IServiceCollection services)
    {
        const string _baseUrl = "https://medium.com/_/graphql";
        
        services.AddHttpClient();
        
        services.AddSingleton(sp =>
        {
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });

            client.BaseAddress = new Uri(_baseUrl);

            const string clientName = "lite";
            const string clientVersion = "main-20221118-211927-5dd34a429b";
            
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("apollographql-client-name", clientName);
            client.DefaultRequestHeaders.Add("apollographql-client-version", clientVersion);
            //client.DefaultRequestHeaders.Add("cookie", "_ga=GA1.2.67276409.1659947436; _gid=GA1.2.1251858898.1668776369; g_state={\"i_p\":1668862776415,\"i_l\":2}; nonce=KLKzcrKo; lightstep_guid/medium-web=5c28a44477b06c61; lightstep_session_id=680d0a86402d9ebe; sz=1864; pr=1; tz=-120; uid=61b0b184c64b; sid=1:Yyw+NRDxZ9cUQXHM+HrfJOE0wFBx7+qlzhd42P8z/pI1DR1KR6tToiuEXgCfrnTK; xsrf=G4wpupZWFCIqdrhV; __cfruid=17a2dbf46411f475b87c52ddd57afd041d8bf97c-1668839770; _gat=1; _dd_s=rum=0&expire=1668848474527; dd_cookie_test_bea070c1-d97a-4d81-83f5-ec28f9909098=test; dd_cookie_test_d0e82af3-3f5a-437c-92af-7d728ac24580=test; dd_cookie_test_4da5a60b-cf0f-4b65-91c4-ede315c04b5f=test");
            //client.DefaultRequestHeaders.Add("content-type", "application/json");
            //client.DefaultRequestHeaders.Add("graphql-operation", "TopicFeedQuery");
            client.DefaultRequestHeaders.Add("medium-frontend-app", $"{clientName}/{clientVersion}");
            client.DefaultRequestHeaders.Add("origin", "https://medium.com");
            // client.DefaultRequestHeaders.Add("ot-tracer-sampled", "true");
            // client.DefaultRequestHeaders.Add("ot-tracer-spanid", "7dd67633050403f3");
            // client.DefaultRequestHeaders.Add("ot-tracer-traceid", "136a8437a6f3de69");
            client.DefaultRequestHeaders.Add("sec-ch-ua", """ "Chromium";v="106", "Not.A/Brand";v="24", "Opera GX";v="92" """);
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", """ "Windows" """);
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36 OPR/92.0.0.0");

            return client;
        });
        
        services.AddSingleton<IAggregatorClient, Client>();

        return services;
    }
}