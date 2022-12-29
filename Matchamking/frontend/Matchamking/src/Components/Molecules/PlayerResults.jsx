import React, { useEffect, useState } from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import Player from '../Atoms/Player'
import styled from 'styled-components'


const PlayerResults = (
    {selectedPlayers, setSelectedPlayers,
    remainingPlayers, setRemainingPlayers}
) => {

    const [ playerClicked, setPlayerClicked] = useState();

    useEffect(() => {
        let newArr = remainingPlayers.filter(el => el.nickname !== playerClicked.nickname);
        let newSelectedPlayers = selectedPlayers;
        setRemainingPlayers(newArr);
        if (playerClicked !== undefined)
            newSelectedPlayers.push(playerClicked)
        console.log(playerClicked)
      }, [playerClicked])


  return (
    <>
        {
            remainingPlayers.map(item => 
                <Player victorias={item.victorias}
                    nickname={item.nickname}
                    players={remainingPlayers}
                    setPlayerClicked={setPlayerClicked}
                    key={item.nickname}
                ></Player>
        )}
    </>
  )
}

export default PlayerResults