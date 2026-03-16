import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';

// DEFECTO INTENCIONAL: URL hardcodeada en vez de usar environment.ts
const API_URL = 'http://localhost:5000/api';

export interface TaskItem {
  id: number;
  title: string;
  description: string;
  status: string;   // DEFECTO: magic string en vez de enum
  projectId: number;
  assignedToUserId?: number;
  createdAt: string;
  dueDate?: string;
}

export interface Project {
  id: number;
  name: string;
  description: string;
  tasks: TaskItem[];
}

@Injectable({
  providedIn: 'root',
})
// DEFECTO INTENCIONAL: sin manejo de errores (sin catchError, sin loading state)
export class TaskService {
  constructor(private http: HttpClient) {}

  getTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(`${API_URL}/tasks`);
  }

  getTask(id: number): Observable<TaskItem> {
    return this.http.get<TaskItem>(`${API_URL}/tasks/${id}`);
  }

  createTask(task: Partial<TaskItem>): Observable<TaskItem> {
    return this.http.post<TaskItem>(`${API_URL}/tasks`, task);
  }

  updateTask(id: number, task: Partial<TaskItem>): Observable<TaskItem> {
    return this.http.put<TaskItem>(`${API_URL}/tasks/${id}`, task);
  }

  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/tasks/${id}`);
  }

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${API_URL}/projects`);
  }

  // Mock methods for demo purposes
  getMockTasks(): Observable<TaskItem[]> {
    // BUG #1: 'statuss' typo — this task will render a blank status badge
    const mockTasks: any[] = [
      { id: 1, title: 'Set up CI/CD pipeline', statuss: 'In Progress', projectId: 1, createdAt: '2026-01-10', dueDate: '2026-03-20', description: 'Configure automated build and deploy.' },
      { id: 2, title: 'Design database schema', status: 'Done', projectId: 1, createdAt: '2026-01-05', dueDate: '2026-02-15', description: 'Define tables and relationships.' },
      { id: 3, title: 'Write unit tests', status: 'Open', projectId: 2, createdAt: '2026-02-01', dueDate: '2026-04-01', description: 'Achieve 80% coverage.' },
      { id: 4, title: 'Deploy to staging', status: 'Open', projectId: 1, createdAt: '2026-02-10', dueDate: '2026-03-30', description: 'Push latest build to staging env.' },
      { id: 5, title: 'Code review sprint 3', status: 'Done', projectId: 2, createdAt: '2026-02-20', dueDate: '2026-03-05', description: 'Review all PRs from sprint 3.' },
    ];
    return of(mockTasks as TaskItem[]).pipe(delay(600));
  }

  getMockProjects(): Observable<Project[]> {
    const mockProjects: Project[] = [
      { id: 1, name: 'Backend API', description: 'REST API built with .NET 10', tasks: [] },
      { id: 2, name: 'Frontend UI', description: 'Angular 21 dashboard', tasks: [] },
      { id: 3, name: 'DevOps', description: 'CI/CD and cloud infrastructure', tasks: [] },
    ];
    return of(mockProjects).pipe(delay(400));
  }
}
