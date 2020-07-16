﻿using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() {
        // 발판을 리셋하는 처리
    }

    void OnCollisionEnter2D(Collision2D obj) {
        if(obj.gameObject.tag == "Player")
        {
            GameManager.instance.AddScore(1);
            stepped = true;
        }
    }
    public void StepReset() => stepped = false;
}