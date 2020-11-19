using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.EntityFrameworkCore;
using TestBlocklyHtml.DB;
using TestBlocklyHtml.resolveAtRuntime;

namespace TestBlocklyHtml.Controllers
{
    public class GenericsTest<T>
    {
        public T t { get; set; }
    }


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VariousTestsController : ControllerBase
    {
        
        public VariousTestsController()
        {
        }


        [HttpPost]
        public string TestInsideVariable(WithInsideClass id)
        {
            return "this is " + id.t.Ind + "=>" + id.t.a;
        }
        [HttpPost]
        public string TestGeneric(GenericsTest<Test> id)
        {
            return "this is " + id.t.Ind+ "=>" + id.t.a;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Department>> GetDepartment([FromServices] testsContext context, string name)
        {
            name = name?.ToLower();
            var department = await context.Department.AsNoTracking()
                .Include(it => it.Employee).FirstOrDefaultAsync(it => it.Name.ToLower() == name);
            //var department = await _context.Department.FirstOrDefaultAsync(it => it.Iddepartment == id);
            if (department == null)
            {
                return NotFound();
            }
            foreach (var emp in department.Employee)
            {
                emp.IddepartmentNavigation = null;
            }
            return department;
        }
        [HttpGet("{id?}")]
        public string ActionWithNullParameter(int? id)
        {
            return (id == null) ? "from GET no parameter" : $"from GET parameter {id}";
        }

        [HttpGet("{id?}")]
        public string TestNullPassing(int? id)
        {
            return (id == null) ? "OK RESULT" : throw new Exception($"should not have {id}");
        }
        [HttpPatch("{id?}")]
        public string ActionWithNullParameterPATCH(int? id)
        {
            return (id == null) ? "from PATCH no parameter" : $"from PATCH parameter {id}";
        }
        [HttpGet("{id}")]
        public string ActionWith2ParametersAndARoute(int id, int x, int y)
        {
            return $"received route {id} and parameters {x} {y}";
        }

        [HttpPost()]
        public string ActionWithDictionary([FromBody]Dictionary<string, string> id)
        {
            var str =
                string.Join(",",
                id.Select(it => it.Key + "= " + it.Value)
                );
            return $"received {str}";
        }

        [HttpGet]
        public string AddRuntimeController([FromServices] ApplicationPartManager partManager, [FromServices]MyActionDescriptorChangeProvider provider)
        {
            string name = "andrei" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var ass = CreateController(name);
            
            if (ass != null)
            {
                partManager.ApplicationParts.Add(new AssemblyPart(ass));
                // Notify change
                provider.HasChanged = true;
                provider.TokenSource.Cancel();
                return "api/"+ name;
            }
            throw new Exception("controller not generated");
        }

        private Assembly CreateController(string name)
        {
            
            string code = new StringBuilder()
                .AppendLine("using System;")
                .AppendLine("using Microsoft.AspNetCore.Mvc;")
                .AppendLine("namespace TestBlocklyHtml.Controllers")
                .AppendLine("{")
                .AppendLine("[Route(\"api/[controller]\")]")
                .AppendLine("[ApiController]")
                .AppendLine(string.Format("public class {0} : ControllerBase", name))
            
                .AppendLine(" {")
                .AppendLine("  public string Get()")
                .AppendLine("  {")
                .AppendLine(string.Format("return \"test - {0}\";", name))
                .AppendLine("  }")
                .AppendLine(" }")
                .AppendLine("}")
                .ToString();

            var codeString = SourceText.From(code);
            var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

            var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(RouteAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ApiControllerAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ControllerBase).Assembly.Location),
            };

            var codeRun = CSharpCompilation.Create("Hello.dll",
                new[] { parsedSyntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                    optimizationLevel: OptimizationLevel.Release,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
            using (var peStream = new MemoryStream())
            {
                if (!codeRun.Emit(peStream).Success)
                {
                    return null;
                }
                return Assembly.Load(peStream.ToArray());
            }



        }
        [HttpGet()]
        public string[] ReturnArrayStringForGrid()
        {
            return new[]
            {
                "Andrei",
                "Ignat",
                "http://msprogrammer.serviciipeweb.ro/"
            };
        }
        [HttpGet()]
        public string boolTest(bool data)
        {
            return "you give " + data;
        }

        }
}