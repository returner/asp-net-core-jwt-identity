using MediatR;

namespace AspNetCoreJwtIdentity.Repositories.MediatR
{
    public class LibraryEntrypoint
    { }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Age { get; set; }
    }

    public interface IDataAccess
    {
        List<Student> GetStudents();
        Student AddStudent(string firstName, string lastName, double age);
        Student GetStudentById(int id);
    }

    public class DataAccess : IDataAccess
    {
        private List<Student> student = new List<Student>();
        public DataAccess()
        {
            student.Add(new Student { Id = 1, FirstName = "John", LastName = "Doe", Age = 23 });
            student.Add(new Student { Id = 1, FirstName = "Jane", LastName = "Doe", Age = 45 });
        }

        public List<Student> GetStudents()
        {
            return student;
        }

        public Student AddStudent(string firstName, string lastName, double age)
        {
            Student s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.Age = age;
            s.Id = student.Count() + 1;
            student.Add(s);
            return s;
        }

        public Student GetStudentById(int id)
        {
            var stu = student.Where(d => d.Id.Equals(id)).FirstOrDefault();
            return stu;
        }
    }

    public class GetStudentListQuery : IRequest<List<Student>>
    { 
    }

    public class GetSTudentListHandler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        private readonly IDataAccess _dataAccess;

        public GetSTudentListHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;

        public Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetStudents());
        }
    }
    public record AddStudentCommand(string firstName, string lastName, double age) : IRequest<Student>;
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IDataAccess _dataAccess;
        public AddStudentHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;

        public Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddStudent(request.firstName, request.lastName, request.age));
        }
    }

    public class MediatRController
    {
        private readonly IMediator _mediator;

        public MediatRController(IMediator mediator) => _mediator = mediator;

        public async Task<List<Student>> GetListOfStudents()
        {
            var result =  await _mediator.Send(new GetStudentListQuery());
            return result;
        }


    }
}
