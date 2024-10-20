export interface Poll {
  id: number; // Add an id field if needed
  question: string;
  options: Option[];
}

export interface Option {
  optionText: string;
}

export interface Question {
  id: number;
  questionText: string;
  options: Option[];
}

