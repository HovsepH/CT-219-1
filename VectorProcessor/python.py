import numpy as np
 
class VectorProcessor:
    def __init__(self, size=25, value_range=(1, 20)):
        self.size = size
        self.value_range = value_range
        self.sorted_vector = None
        self.create_sort_vector()
 
    def create_sort_vector(self):
        self.sorted_vector = np.sort(np.random.randint(self.value_range[0], self.value_range[1], size= self.size))
        print("Original sorted vector:", self.sorted_vector)
 
    def remove_duplicates(self):
        n = len(self.sorted_vector)
        unique_index = 0
 
        for index in range(1, n):
            if self.sorted_vector[index] != self.sorted_vector[unique_index]:
                unique_index += 1
                self.sorted_vector[unique_index] = self.sorted_vector[index]
 
        for index in range(unique_index + 1, n):
            self.sorted_vector[index] = 0
 
        return unique_index + 1 
 
    def display_results(self):
        print("Sorted vector with duplicates removed:", self.sorted_vector)
        
 
 
vector_processor = VectorProcessor()
k = vector_processor.remove_duplicates()
print("\nk =", k)      
vector_processor.display_results()