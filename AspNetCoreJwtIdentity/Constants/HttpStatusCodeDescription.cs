namespace AspNetCoreJwtIdentity.Constants
{
    public class HttpStatusCodeDescription
    {
        public const string Ok = "성공 (결과는 없을수 있음)";
        public const string BadRequest = "유효하지 않은 파라미터나 예외등의 모든 오류";
        public const string Unauthorized = "인증 토큰이 없거나 유효기간 만료등의 모든 토큰 오류";
        public const string Forbidden = "인증 정책에 맞지 않아 사용이 불가능한 사용자";
    }
}
