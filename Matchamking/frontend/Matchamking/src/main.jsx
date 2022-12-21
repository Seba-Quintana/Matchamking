import React from 'react'
import ReactDOM from 'react-dom/client'
import Home from './Views/Home'
import './App.css'
import Box from './Components/Atoms/Box'
import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import Matchmaking from './Views/Matchmaking'

const router = createBrowserRouter ([
  {
    path: '/',
    element: <Home/>,
  },
  {
    path: '/matchmaking',
    element: <Matchmaking/>
  }
])

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
