import { Component, OnInit } from '@angular/core';
import { PollService } from '../../services/poll.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-vote-poll',
  templateUrl: './vote-poll.component.html',
  styleUrls: ['./vote-poll.component.css']
})
export class VotePollComponent implements OnInit {
  polls: any[] = [];
  selectedPoll: any = null; // Store selected poll for voting
  voteForm: FormGroup;

  constructor(private pollService: PollService, private fb: FormBuilder) {
    this.voteForm = this.fb.group({
      selectedOption: ['']
    });
  }

  ngOnInit(): void {
    this.fetchPolls();
  }

  // Fetch existing polls
  fetchPolls(): void {
    this.pollService.getPolls().subscribe(response => {
      this.polls = response;
    }, error => {
      console.error('Failed to fetch polls', error);
    });
  }

  // Set selected poll for voting
  onPollSelect(poll: any): void {
    this.selectedPoll = poll;
    this.voteForm.reset(); // Reset form when selecting a new poll
  }

  // Submit vote
  onVote(): void {
    if (this.voteForm.valid && this.selectedPoll) {
      const selectedOption = this.voteForm.value.selectedOption;

      this.pollService.submitVote(this.selectedPoll.id, selectedOption).subscribe(response => {
        console.log('Vote submitted successfully', response);
        // Optionally reset the selected poll or redirect to results
        this.selectedPoll = null; // Deselect poll after voting
      }, error => {
        console.error('Failed to submit vote', error);
      });
    } else {
      console.error('Form is invalid or no poll selected');
    }
  }
}
