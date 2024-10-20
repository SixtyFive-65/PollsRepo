export interface Poll {
  id: number; 
  question: string;
  options: Option[];
}

export interface Option {
  id: number;
  optionText: string;
  voteCount: number
}

export interface Question {
  id: number;
  questionText: string;
  options: Option[];
}

