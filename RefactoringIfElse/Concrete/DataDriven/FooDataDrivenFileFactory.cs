using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System;

namespace RefactoringIfElse.Concrete.DataDriven
{
    public class FooDataDrivenFileFactory
    {
        private readonly IDbRepository _dbRepository;
        private readonly IApiAccess _apiAccess;

        public FooDataDrivenFileFactory(IDbRepository dbRepository, IApiAccess apiAccess)
        {
            _dbRepository = dbRepository;
            _apiAccess = apiAccess;
        }

        public FooDataDriven Create(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var nodes = JsonSerializer.Deserialize<ConfigNode[]>(jsonData);

            var creators = new List<HandlerCreator>();
            foreach(var node in nodes)
            {
                Lazy<IHandler> handler;
                switch (node.type)
                {
                    case "book":
                        handler = new Lazy<IHandler>(() => new BookHandler(_dbRepository, _apiAccess, node.value));
                        break;
                    case "song":
                        handler = new Lazy<IHandler>(() => new SongHandler(_dbRepository, _apiAccess, node.value)); 
                        break;
                    case "movie":
                        handler = new Lazy<IHandler>(() => new MovieHandler(_apiAccess, node.value)); 
                        break;
                    default:
                        throw new ArgumentException($"invalid node type: {node.type}");
                }
                creators.Add(new HandlerCreator(path => path.StartsWith(node.filter), path => handler.Value));
            }

            var factory = new HandlerFactory(creators);
            return new FooDataDriven(factory);
        }

        private record ConfigNode(string filter, string value, string type);
    }
}