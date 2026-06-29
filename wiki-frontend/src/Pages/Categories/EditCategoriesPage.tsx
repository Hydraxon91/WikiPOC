import { useState, useEffect } from 'react';
import { addCategory, deleteCategory, fetchCategories } from '../../Api/wikiApi';
import './Style/categorypagestyle.css';
import { useStyleContext } from '../../Components/contexts/StyleContext';

const EditCategoriesPage = ({ setAppCategories, jwtToken }) => {
    const [categories, setCategories] = useState([]);
    const [newCategory, setNewCategory] = useState('');
    const {styles} = useStyleContext();

    useEffect(() => {
        fetchCategories()
        .then(categories => {
            setCategories(categories);
        })
        .catch(error => {
            console.error('Error fetching categories:', error);
        });
      }, []);

    const handleChange = (event) => {
      setNewCategory(event.target.value);
    };
  
    const handleAddCategory = async () => {
        try{
            const addedCategory = await addCategory(newCategory, jwtToken);
            if (addedCategory) {

                setNewCategory('');
                const updatedCategories = [...categories, addedCategory];
                const updatedCategorieNames = updatedCategories.map(category => category.categoryName);
                setCategories(updatedCategories);
                setAppCategories(updatedCategorieNames);
            } else {
                console.error(`Failed to add category ${newCategory}.`);
            }
        } catch (error) {
          console.error('Error deleting category:', error.message);
        }
    };
  
    const handleDeleteCategory = async (category) => {
        try {
            const categoryId = category.id; 
            await deleteCategory(categoryId, jwtToken);

            const updatedCategories = categories.filter(cat => cat.id !== categoryId);
            const updatedCategorieNames = updatedCategories.map(category => category.categoryName);
            setCategories(updatedCategories);
            setAppCategories(updatedCategorieNames);
          } catch (error) {
            console.error('Error deleting category:', error.message);
          }
    };
  
    return (
      <div className="article" style={{backgroundColor: styles.articleColor}}>
        <p className='cat-text'>Categories:</p>
        <ul>
          {categories.map((category, index) => (
            <li key={index}>
              <div className='category-row'>
                <span>{category.categoryName}</span>
                {category.wikiPages.length ==0 && <button onClick={() => handleDeleteCategory(category)}>Delete Category</button>}
              </div>
            </li>
          ))}
        </ul>
        <div>
          <input
            type="text"
            value={newCategory}
            onChange={handleChange}
            placeholder="Enter new category"
          />
          <button onClick={handleAddCategory}>Add Category</button>
        </div>
      </div>
    );
  };

export default EditCategoriesPage;
