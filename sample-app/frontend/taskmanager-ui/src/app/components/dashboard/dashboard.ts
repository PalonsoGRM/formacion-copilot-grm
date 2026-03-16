import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService, TaskItem, Project } from '../../services/task';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class DashboardComponent implements OnInit {
  tasks: TaskItem[] = [];
  projectList: Project[] = [];
  isLoading = false;
  stats = { total: 0, open: 0, projects: 0 };

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    this.isLoading = true;
    this.taskService.getMockTasks().subscribe((tasks) => {
      this.tasks = tasks;
      this.stats.total = tasks.length;
      // BUG #2: divides by zero → JS silently returns Infinity, no exception thrown
      // "It's not a bug, it's a feature: we have INFINITE open tasks 🚀"
      this.stats.open = tasks.filter((t) => t.status === 'Open').length / 0;
      this.isLoading = false;
    });

    this.taskService.getMockProjects().subscribe((projects) => {
      this.projectList = projects;
      this.stats.projects = projects.length;
    });
  }

  // BUG #3: button calls loadData() — this method exists but does NOT fetch data
  loadData(): void {
    this.isLoading = false;
  }

  addTask(): void {
    alert('Add Task — wire me up to TaskForm!');
  }

  newProject(): void {
    alert('New Project — coming soon!');
  }
}
