import { Component, OnInit } from '@angular/core';
import { PollService } from '../../services/poll.service'; // Adjust the path as needed
import { Poll } from '../../models/Poll.model';

@Component({
  selector: 'app-view-polls',
  templateUrl: './view-polls.component.html',
  styleUrl: './view-polls.component.css'
})
export class ViewPollsComponent implements OnInit{
  polls: Poll[] = [];
  loading: boolean = true;
  error: string | null = null;

  constructor(private pollService: PollService) {}

  ngOnInit(): void {
    this.fetchPolls();
  }

  fetchPolls(): void {
    this.pollService.getPolls().subscribe({
      next: (data) => {
        this.polls = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error fetching polls', err);
        this.error = 'Could not load polls';
        this.loading = false;
      }
    });
  }
}