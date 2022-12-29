import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import Board from '../Components/Organisms/Board'

const Leaderboard = () => {
  return (
    <>
          <BackArrow navigate={'/'}></BackArrow>
          <Board></Board>
    </>
  )
}

export default Leaderboard