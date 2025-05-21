using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Exceptions;

namespace TaskBoard.Domain.Entities
{
    public class BoardTask
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public TaskPriority Priority { get; private set; }
        public Enums.TaskStatus Status { get; private set; }

        public BoardTask(string title, string? description, TaskPriority priority)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description ?? string.Empty;
            Priority = priority;
            Status = Enums.TaskStatus.ToDo;

            Validate();
        }

        private void Validate()
        {
            List<ErrorDomainField> errors = new List<ErrorDomainField>();

            if (string.IsNullOrWhiteSpace(Title))
            {
                errors.Add(new ErrorDomainField
                {
                    Field = "Title",
                    Message = "Title is required for task creation."
                });
            }

            if (!Enum.IsDefined(typeof(TaskPriority), Priority))
            {
                errors.Add(new ErrorDomainField
                {
                    Field = "Priority",
                    Message = "Invalid priority."
                });
            }

            if (errors.Count > 0)
            {
                throw new InvalidBoardTask(errors);
            }
        }

        public void MoveToDoing()
        {
            if (Status != Enums.TaskStatus.ToDo)
            {
                throw new InvalidBoardTask(new List<ErrorDomainField> {
                new ErrorDomainField {
                    Field = "TaskStatus",
                    Message = "For move the task to 'DOING' status, the status need to be 'TO DO'."
                }
               });
            }

            Status = Enums.TaskStatus.Doing;
        }

        public void MoveToDone()
        {
            if (Status != Enums.TaskStatus.Doing)
            {
                throw new InvalidBoardTask(new List<ErrorDomainField>
                {
                    new ErrorDomainField
                    {
                        Field = "TaskStatus",
                        Message = "For move the task to 'DONE' status, the status need to be 'DOING'."
                    }
                });
            }

            Status = Enums.TaskStatus.Done;
        }
    }
}
