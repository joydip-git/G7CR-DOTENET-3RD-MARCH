import { useEffect, useState } from 'react'
import './App.css'
import { type Product } from './models/product'
import Sample from './Sample'

function App() {
  const [products, setProducts] = useState<Product[]>([])
  const [loadingOver, setLoadingOver] = useState(false)
  const [errorMessage, setErrorMessage] = useState('')

  const fetchProducts = async () => {
    try {
      const response = await fetch("http://localhost:5011/api/product/all");
      const data = (await response.json()) as Product[];
      setProducts(data);
      setErrorMessage('')
      setLoadingOver(true)
    } catch (error: any) {
      setProducts([]);
      setErrorMessage(error.message)
      setLoadingOver(true)
    }
  }
  useEffect(
    () => {
      fetchProducts();
    },
    []
  )

  let design;
  if (!loadingOver)
    design = <span> loading...</span>
  else if (errorMessage !== '')
    design = <span>{errorMessage}</span>
  else if (products.length === 0)
    design = <span> no products</span>
  else
    design = (
      <>
        <table>
          <thead>
            <tr>
              <td>Id</td>
              <td>Name</td>
              <td>Price</td>
              <td>Description</td>
            </tr>
          </thead>
          <tbody>
            {
              products.map(
                p => (
                  <tr>
                    <td>{p.id}</td>
                    <td>{p.name}</td>
                    <td>{p.price}</td>
                    <td>{p.description}</td>
                  </tr>
                )
              )
            }
          </tbody>
        </table>
      </>
    )
  return <div>
    <Sample />
    <br />
    {design}
  </div>
}

export default App
