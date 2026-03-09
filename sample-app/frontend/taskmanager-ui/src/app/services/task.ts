import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
}
