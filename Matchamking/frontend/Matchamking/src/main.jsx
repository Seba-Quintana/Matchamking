import React from 'react'
import ReactDOM from 'react-dom/client'
import Home from './Views/Home'
import './App.css'
import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import Matchmaking from './Views/Matchmaking'
import AddPlayer from './Views/AddPlayer'
import MatchHistory from './Views/MatchHistory'
import Leaderboard from './Views/Leaderboard'
import Admin from './Views/Admin'

const router = createBrowserRouter ([
  {
    path: '/',
    element: <Home/>,
  },
  {
    path: '/matchmaking',
    element: <Matchmaking/>
  },
  {
    path: '/addplayer',
    element: <AddPlayer/>,
  },
  {
    path: '/history',
    element: <MatchHistory/>,
  },
  {
    path: '/leaderboard',
    element: <Leaderboard/>
  },
  {
    path: '/admin',
    element: <Admin/>
  },
])

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
