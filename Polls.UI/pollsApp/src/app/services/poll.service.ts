import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PollService {
  private apiUrl = environment.apiUrl;; 

  constructor(private http: HttpClient) {}

  // Create a new poll
  createPoll(pollData: any): Observable<any> {
    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`, 
      'Content-Type': 'application/json' 
    });

    return this.http.post(`${this.apiUrl}/createpoll`, pollData, {headers});
  }

  // Get existing polls
  getPolls(): Observable<any> {
    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`, 
      'Content-Type': 'application/json' 
    });

    return this.http.get<any[]>(`${this.apiUrl}/GetPolls`,{headers});
  }

  // Submit a vote for a poll
  submitVote(pollId: string, optionId: string): Observable<any> {
    const token = localStorage.getItem('token');
    
    console.log({ pollId, optionId });

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`, 
      'Content-Type': 'application/json' 
    });

    var payload = {pollId, optionId };

    return this.http.post(`${this.apiUrl}/vote`, payload, {headers});
  }
}
