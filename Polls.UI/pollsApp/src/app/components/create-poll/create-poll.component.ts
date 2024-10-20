import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { PollService } from '../../services/poll.service'; // Adjust the path based on your structure

@Component({
  selector: 'app-create-poll',
  templateUrl: './create-poll.component.html',
  styleUrls: ['./create-poll.component.css']
})
export class CreatePollComponent implements OnInit {
  pollForm: FormGroup;
  createError: boolean = false;

  constructor(private fb: FormBuilder, private pollService: PollService) {
    this.pollForm = this.fb.group({
      question: ['', Validators.required],
      options: this.fb.array([
        this.createOption() // Initialize with one option
      ])
    });
  }

  ngOnInit(): void {}

  get options(): FormArray {
    return this.pollForm.get('options') as FormArray;
  }

  createOption(): FormGroup {
    return this.fb.group({
      optionText: ['', Validators.required]
    });
  }

  addOption(): void {
    this.options.push(this.createOption());
  }

  removeOption(index: number): void {
    this.options.removeAt(index);
  }

  onSubmit(): void {
    if (this.pollForm.valid) {
      const pollData = this.pollForm.value;
      console.log('Poll Data:', pollData);

      // Call the PollService to submit the poll data
      this.pollService.createPoll(pollData).subscribe(response => {
        console.log('Poll created successfully', response);
        // Optionally reset the form or navigate to another page

        this.pollForm.reset();
        this.options.clear(); // Clear options
        this.addOption(); // Add one option back
      }, error => {
        this.createError = true;
        console.error('Error creating poll', error);
      });
    } else {
      console.error('Form is invalid');
    }
  }
}
