# Task Tracker

Sample solution for the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh/).

This is a simple command-line interface (CLI) application for managing tasks.

## Features

- Add new tasks with a unique ID and store it in `JSON` format.
- List tasks by their status: `to-do`, `in-progress`, or `done`.
- Update the description and/or status of an existing task.
- Delete tasks by their ID.
- Show status of tasks as `in-progress`, `done` or `to-do`.

## Prerequisites

- .NET 8.0 installed on your system.

## Installation

**Clone the Repository**

   ```bash
   git clone --depth=1 https://github.com/Aj-Seven/backend-projects

   # Navigate to the project Directory
   cd [`Your project directory`]
   ```
## Usage

- **Add a Task**
```bash
dotnet run add "Drink a Coffee"
```

- **List all Tasks**
```bash
dotnet run list
```
- **or by list the tasks by status**
```Power Shell
# To list the tasks that are marked as to-do
dotnet run list "to-do"

# To list the tasks that are marked as in-progess
dotnet run list "in-progress"

# To list the tasks that are marked as done
dotnet run list "done"
```

- **Update a Task**
# You can update either status, description or both 
```bash
dotnet run update 1 "Drink a Coffee and Do Coding"
```

- **Delete a Task**
```bash
# Delete the task by containing its ID 1
dotnet run delete 1
```

### Sample JSON structure
```JSON
[
  {
    "id": 1,
    "description": "Drink a Coffee",
    "status": "to-do"
  }
]
```
