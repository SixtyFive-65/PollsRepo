export interface Option {
  optionText: string;
}

export interface Poll {
  id: number; // Add an id field if needed
  question: string;
  options: Option[];
}