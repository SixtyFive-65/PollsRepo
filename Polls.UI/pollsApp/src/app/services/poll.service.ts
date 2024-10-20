import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class PollService {
  private apiUrl = environment.apiUrl;; 

  constructor(private http: HttpClient) {}

  // Create a new poll
  createPoll(pollData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/createpoll`, pollData);
  }

  // Get existing polls
  getPolls(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  // Submit a vote for a poll
  submitVote(pollId: string, optionId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/${pollId}/vote`, { optionId });
  }
}
